using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Profiling;
using UnityEngine;

[System.Serializable]
public struct StepData
{
    public float CPUTimeMs;
    public float GPUTimeMs;

    public StepData(float cpuTimeMs, float gpuTimeMs)
    {
        CPUTimeMs = cpuTimeMs;
        GPUTimeMs = gpuTimeMs;
    }
}

[System.Serializable]
public class PerformanceData
{
    public List<StepData> Steps = new List<StepData>();
}

public class PerformanceProfiler : MonoBehaviour
{
    [Header("Performance Settings")]
    [SerializeField] private bool _shouldMeasure = false;
    public bool IsMeasuring { get { return _shouldMeasure; } }

    [SerializeField] private string _customFilename = string.Empty;

    // Save variables
    private const string _defaultFilename = "Performance";
    private const float _saveFrequency = 1.0f;

    private string _filePath = string.Empty;

    private List<StepData> _stepsToSave = new List<StepData>();

    // Profilers
    private ProfilerRecorder _cpuRecorder = new ProfilerRecorder();
    private ProfilerRecorder _gpuRecorder = new ProfilerRecorder();

    private void Start()
    {
        if (_shouldMeasure)
        {
            // Create the directory, if needed
            string directory = Path.Combine(Application.persistentDataPath, "Measurements");
            Directory.CreateDirectory(directory);

            // Set file path
            string filename = ((_customFilename == string.Empty) ? _defaultFilename : _customFilename) + ".json";
            _filePath = Path.Combine(directory, filename);

            // Make sure the measurements start from an empty file
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            // Start the coroutine to periodically save data
            StartCoroutine(SaveStepsCoroutine());

            // Initialize profilers
            _cpuRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "CPU Main Thread Frame Time");
            _gpuRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Render, "GPU Frame Time");
        }
    }

    private void OnDestroy()
    {
        // Do a final save of the last steps
        if (_shouldMeasure)
        {
            StopCoroutine(nameof(SaveStepsCoroutine));
            SaveSteps();

            // Dispose profilers
            _cpuRecorder.Dispose();
            _gpuRecorder.Dispose();
        }
    }

    private IEnumerator SaveStepsCoroutine()
    {
        while (_shouldMeasure)
        {
            // Wait before saving steps
            yield return new WaitForSeconds(_saveFrequency);

            SaveSteps();
        }
    }

    private void SaveSteps()
    {
        // Check if there are steps to save
        if (_stepsToSave.Count == 0) return;

        // Get previous saved steps
        PerformanceData performanceData = new PerformanceData();
        if (File.Exists(_filePath))
        {
            string prevSteps = File.ReadAllText(_filePath);
            performanceData = JsonUtility.FromJson<PerformanceData>(prevSteps);
        }

        // Append new steps
        performanceData.Steps.AddRange(_stepsToSave);

        // Get the json for the save file
        string json = JsonUtility.ToJson(performanceData, true);

        // Save the steps to a file
        File.WriteAllText(_filePath, json);

        // Clear the list of steps
        _stepsToSave.Clear();
    }

    public void MeasurePerformance()
    {
        // Get cpu and gpu time in millieseconds
        float cpuTimeMs = _cpuRecorder.LastValue * (1e-6f);
        float gpuTimeMs = _gpuRecorder.LastValue * (1e-6f);

        // Add step data to save
        _stepsToSave.Add(new StepData(cpuTimeMs, gpuTimeMs));
    }
}
