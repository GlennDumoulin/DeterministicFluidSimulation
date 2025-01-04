// StableFluids - A GPU implementation of Jos Stam's Stable Fluids on Unity
// https://github.com/keijiro/StableFluids

using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

namespace StableFluids
{
    public class Fluid : MonoBehaviour
    {
        #region Editable attributes

        [Header("Fluid Settings")]
        [SerializeField] private int _resolution = 512;
        [SerializeField] private float _viscosity = 1e-6f;
        [SerializeField] private float _force = 300;
        [SerializeField] private float _exponent = 200;
        [SerializeField] private Texture2D _initial = null;

        #endregion

        #region Internal resources

        [SerializeField, HideInInspector] private ComputeShader _compute = null;
        [SerializeField, HideInInspector] private Shader _shader = null;

        #endregion

        #region Private members

        private Material _shaderSheet = null;
        private Vector2 _previousInput = Vector2.zero;

        static class Kernels
        {
            public const int Advect = 0;
            public const int Force = 1;
            public const int PSetup = 2;
            public const int PFinish = 3;
            public const int Jacobi1 = 4;
            public const int Jacobi2 = 5;
        }

        private int _threadCountX = 0;
        private int ThreadCountX
        {
            get { return _threadCountX; }
            set
            {
                _threadCountX = (value + 7) / 8;
                ResolutionX = _threadCountX * 8;
            }
        }
        private int _threadCountY = 0;
        private int ThreadCountY
        {
            get { return _threadCountY; }
            set
            {
                _threadCountY = (value * Screen.height / Screen.width + 7) / 8;
                ResolutionY = _threadCountY * 8;
            }
        }

        private int ResolutionX { get; set; }
        private int ResolutionY { get; set; }

        private float _dxSqr = 0.0f;
        private float _dt = 0.0f;

        private const int _jacobiIterarations = 25;

        private int _clientIdx = 0;

        // Input Queue variables
        private int _currentStep = -1;
        private const int _delaySteps = 5;

        private List<InputData> _inputQueue = new List<InputData>();

        // Force variables
        private const int _maxForces = 10;

        private ComputeBuffer _forcesBuffer = null;
        private ForceData[] _forces = new ForceData[_maxForces];
        private Vector4[] _pourOrigins = new Vector4[_maxForces];

        // Save/Load variables
        private InputSaveLoader _inputSaveLoader = null;
        private PerformanceProfiler _performanceProfiler = null;
        private AccuracyProfiler _accuracyProfiler = null;

        // Vector field buffers
        static class VFB
        {
            public static RenderTexture V1 = null;
            public static RenderTexture V2 = null;
            public static RenderTexture V3 = null;
            public static RenderTexture P1 = null;
            public static RenderTexture P2 = null;
        }

        // Color buffers (for double buffering)
        private RenderTexture _colorRT1 = null;
        private RenderTexture _colorRT2 = null;

        private RenderTexture AllocateBuffer(int componentCount, int width = 0, int height = 0)
        {
            RenderTextureFormat format = RenderTextureFormat.ARGBHalf;
            if (componentCount == 1) format = RenderTextureFormat.RHalf;
            if (componentCount == 2) format = RenderTextureFormat.RGHalf;

            if (width == 0) width = ResolutionX;
            if (height == 0) height = ResolutionY;

            RenderTexture rt = new RenderTexture(width, height, 0, format);
            rt.enableRandomWrite = true;
            rt.Create();
            return rt;
        }

        #endregion

        #region MonoBehaviour implementation

        private void OnValidate()
        {
            // Check minimum resolution
            _resolution = Mathf.Max(_resolution, 8);
        }

        private void ValidateResolution()
        {
            // Check minimum resolution
            _resolution = Mathf.Max(_resolution, 8);

            // Update thread counts
            ThreadCountX = _resolution;
            ThreadCountY = _resolution;
        }

        private void Awake()
        {
            ValidateResolution();

            // Convert const floating-point values to fixed-point and back
            _viscosity = FixedPoint.FixedFloat(_viscosity);
            _force = FixedPoint.FixedFloat(_force);
            _exponent = FixedPoint.FixedFloat(_exponent);

            float dx = FixedPoint.FixedFloat(1.0f / ResolutionY);
            _dxSqr = FixedPoint.FixedFloat(dx * dx);
            _dt = FixedPoint.FixedFloat(Time.fixedDeltaTime);

            // Check for required components
            _inputSaveLoader = GetComponent<InputSaveLoader>();
            Assert.IsTrue(_inputSaveLoader);

            _performanceProfiler = GetComponent<PerformanceProfiler>();
            Assert.IsTrue(_performanceProfiler);

            _accuracyProfiler = GetComponent<AccuracyProfiler>();
            Assert.IsTrue(_accuracyProfiler);
        }

        private void Start()
        {
            // Initialize compute shader and shader sheet
            _shaderSheet = new Material(_shader);

            _compute.SetFloat("DeltaTime", _dt);
            _shaderSheet.SetFloat("_DeltaTime", _dt);

            _compute.SetFloat("ForceExponent", _exponent);
            _shaderSheet.SetFloat("_ForceExponent", _exponent);

            // Initialize forces buffer
            _forcesBuffer = new ComputeBuffer(_maxForces, sizeof(float) * 4);

            // Allocate buffers
            VFB.V1 = AllocateBuffer(2);
            VFB.V2 = AllocateBuffer(2);
            VFB.V3 = AllocateBuffer(2);
            VFB.P1 = AllocateBuffer(1);
            VFB.P2 = AllocateBuffer(1);

            _colorRT1 = AllocateBuffer(4, Screen.width, Screen.height);
            _colorRT2 = AllocateBuffer(4, Screen.width, Screen.height);

            Graphics.Blit(_initial, _colorRT1);

#if UNITY_IOS
            Application.targetFrameRate = 60;
#endif
        }

        private void OnDestroy()
        {
            // Destroy all textures and buffers
            Destroy(_shaderSheet);

            Destroy(VFB.V1);
            Destroy(VFB.V2);
            Destroy(VFB.V3);
            Destroy(VFB.P1);
            Destroy(VFB.P2);

            Destroy(_colorRT1);
            Destroy(_colorRT2);

            _forcesBuffer.Release();
        }

        private void FixedUpdate()
        {
            // Increase current step
            ++_currentStep;

            // Don't handle new inputs when data was loaded
            if (_inputSaveLoader.GetState() != InputSaveLoader.SaveLoadState.Loading)
            {
                // Input point
                Vector2 inputPos = new Vector2(
                    (Input.mousePosition.x - Screen.width * 0.5f) / Screen.height,
                    (Input.mousePosition.y - Screen.height * 0.5f) / Screen.height
                );

                // Check for new inputs
                if (Input.GetMouseButton(1))
                {
                    // Queue Random push input
                    QueueInput(
                        FixedVector2.FixedFloats(inputPos),
                        FixedVector2.FixedFloats(_force * 0.025f * Random.insideUnitCircle),
                        false
                    );
                }
                else if (Input.GetMouseButton(0))
                {
                    // Queue Mouse drag input
                    QueueInput(
                        FixedVector2.FixedFloats(inputPos),
                        FixedVector2.FixedFloats((inputPos - _previousInput) * _force),
                        true
                    );
                }

                _previousInput = inputPos;
            }
            else
            {
                // Get the inputs that will be queued this step
                List<InputData> inputsToQueue = _inputSaveLoader.GetQueueableInputs(_currentStep + _delaySteps);
                foreach (InputData input in inputsToQueue)
                {
                    QueueLoadedInput(input);
                }
            }

            // Advection
            _compute.SetTexture(Kernels.Advect, "U_in", VFB.V1);
            _compute.SetTexture(Kernels.Advect, "W_out", VFB.V2);
            _compute.Dispatch(Kernels.Advect, ThreadCountX, ThreadCountY, 1);

            // Diffuse setup
            float dif_alpha = FixedPoint.FixedFloat(_dxSqr / (_viscosity * _dt));
            _compute.SetFloat("Alpha", dif_alpha);
            _compute.SetFloat("Beta", 4 + dif_alpha);
            Graphics.CopyTexture(VFB.V2, VFB.V1);
            _compute.SetTexture(Kernels.Jacobi2, "B2_in", VFB.V1);

            // Jacobi iteration
            for (int i = 0; i < _jacobiIterarations; ++i)
            {
                _compute.SetTexture(Kernels.Jacobi2, "X2_in", VFB.V2);
                _compute.SetTexture(Kernels.Jacobi2, "X2_out", VFB.V3);
                _compute.Dispatch(Kernels.Jacobi2, ThreadCountX, ThreadCountY, 1);
                
                _compute.SetTexture(Kernels.Jacobi2, "X2_in", VFB.V3);
                _compute.SetTexture(Kernels.Jacobi2, "X2_out", VFB.V2);
                _compute.Dispatch(Kernels.Jacobi2, ThreadCountX, ThreadCountY, 1);
            }

            // Get inputs for current step
            List<InputData> inputs = GetCurrentStepInputs();

            // Add external force
            if (inputs.Count > 0)
            {
                int forceCount = 0;
                for (int i = 0; i < inputs.Count; ++i)
                {
                    _forces[forceCount++] = inputs[i].GetForceData();
                }
                _forcesBuffer.SetData(_forces);

                _compute.SetBuffer(Kernels.Force, "Forces", _forcesBuffer);
                _compute.SetInt("ForceCount", forceCount);

                _compute.SetTexture(Kernels.Force, "W_in", VFB.V2);
                _compute.SetTexture(Kernels.Force, "W_out", VFB.V3);

                _compute.Dispatch(Kernels.Force, ThreadCountX, ThreadCountY, 1);
            }
            else
            {
                // Set in buffer for projection setup
                Graphics.CopyTexture(VFB.V2, VFB.V3);
            }

            // Projection setup
            _compute.SetTexture(Kernels.PSetup, "W_in", VFB.V3);
            _compute.SetTexture(Kernels.PSetup, "DivW_out", VFB.V2);
            _compute.SetTexture(Kernels.PSetup, "P_out", VFB.P1);
            _compute.Dispatch(Kernels.PSetup, ThreadCountX, ThreadCountY, 1);

            // Jacobi iteration
            _compute.SetFloat("Alpha", -_dxSqr);
            _compute.SetFloat("Beta", 4);
            _compute.SetTexture(Kernels.Jacobi1, "B1_in", VFB.V2);

            for (int i = 0; i < _jacobiIterarations; ++i)
            {
                _compute.SetTexture(Kernels.Jacobi1, "X1_in", VFB.P1);
                _compute.SetTexture(Kernels.Jacobi1, "X1_out", VFB.P2);
                _compute.Dispatch(Kernels.Jacobi1, ThreadCountX, ThreadCountY, 1);

                _compute.SetTexture(Kernels.Jacobi1, "X1_in", VFB.P2);
                _compute.SetTexture(Kernels.Jacobi1, "X1_out", VFB.P1);
                _compute.Dispatch(Kernels.Jacobi1, ThreadCountX, ThreadCountY, 1);
            }

            // Projection finish
            _compute.SetTexture(Kernels.PFinish, "W_in", VFB.V3);
            _compute.SetTexture(Kernels.PFinish, "P_in", VFB.P1);
            _compute.SetTexture(Kernels.PFinish, "U_out", VFB.V1);
            _compute.Dispatch(Kernels.PFinish, ThreadCountX, ThreadCountY, 1);

            // Gather pour inputs
            int pourCount = 0;
            for (int i = 0; i < inputs.Count; ++i)
            {
                if (inputs[i].IsStirInput) continue;

                _pourOrigins[pourCount++] = new Vector4(inputs[i].ForceOrigin.x, inputs[i].ForceOrigin.y);
            }

            // Apply the velocity field to the color buffer.
            _shaderSheet.SetFloat("_CurrTime", FixedPoint.FixedFloat(_dt * _currentStep));
            _shaderSheet.SetTexture("_VelocityField", VFB.V1);
            _shaderSheet.SetVectorArray("_ForceOrigins", _pourOrigins);
            _shaderSheet.SetInteger("_ForceCount", pourCount);
            Graphics.Blit(_colorRT1, _colorRT2, _shaderSheet, 0);

            // Swap the color buffers
            RenderTexture temp = _colorRT1;
            _colorRT1 = _colorRT2;
            _colorRT2 = temp;

            // Handle the performance measurement
            if (_performanceProfiler.IsMeasuring)
            {
                _performanceProfiler.MeasurePerformance();
            }

            // Handle the accuracy measurement
            if (_accuracyProfiler.IsMeasuring)
            {
                // Check if we are measuring this step
                if (_currentStep == _accuracyProfiler.SaveStep)
                {
                    _accuracyProfiler.MeasureAccuracy(VFB.V1, _colorRT1);
                }
            }
        }

        private void QueueInput(Vector2 forceOrigin, Vector2 forceVector, bool isStirInput)
        {
            // Create the input
            InputData newInput = new InputData(
                forceOrigin, forceVector,
                _currentStep + _delaySteps,
                _clientIdx,
                isStirInput
            );

            // Add the new input to the queue
            _inputQueue.Add(newInput);

            // Check if we are saving inputs
            if (_inputSaveLoader.GetState() == InputSaveLoader.SaveLoadState.Saving)
            {
                _inputSaveLoader.SaveInput(newInput);
            }
        }

        private void QueueLoadedInput(InputData input)
        {
            // Add the new input to the queue
            _inputQueue.Add(input);
        }

        private List<InputData> GetCurrentStepInputs()
        {
            // Check if there are queued inputs
            if (_inputQueue.Count == 0) return new List<InputData>();

            // Get the inputs for the current (or a previous) step
            List<InputData> inputs = _inputQueue
                .Where(input => input.ExecutionStep <= _currentStep)
                .OrderBy(input => input.ExecutionStep)
                .ThenBy(input => input.ClientIdx)
                .Take(_maxForces).ToList();

            // Remove these inputs from the queue
            _inputQueue.RemoveAll(input => inputs.Contains(input));

            return inputs;
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            Graphics.Blit(_colorRT1, destination, _shaderSheet, 1);
        }

        #endregion
    }
}
