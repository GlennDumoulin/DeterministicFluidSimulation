using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class FluidStateData
{
    public List<Vector2> Velocities = new List<Vector2>();
    public List<Color> Colors = new List<Color>();
}

public class AccuracyProfiler : MonoBehaviour
{
    [Header("Accuracy Settings")]
    [SerializeField] private bool _shouldMeasure = false;
    public bool IsMeasuring { get { return _shouldMeasure; } }

    [SerializeField, Range(5, 30)] private int _saveAfterSeconds = 5;
    [SerializeField] private string _customFilename = string.Empty;

    // Save variables
    private const string _defaultFilename = "Accuracy";
    private int _saveStep = 500;
    public int SaveStep { get { return _saveStep; } }

    private string _filePath = string.Empty;

    private void Start()
    {
        if (_shouldMeasure)
        {
            // Set the save step (10 ms/step <-> 100 steps/second)
            _saveStep = _saveAfterSeconds * 100;

            // Create the directory, if needed
            string directory = Path.Combine(Application.persistentDataPath, "Measurements");
            Directory.CreateDirectory(directory);

            // Set file path
            string filename = ((_customFilename == string.Empty) ? _defaultFilename : _customFilename) + $"_{_saveStep}.json";
            _filePath = Path.Combine(directory, filename);

            // Make sure the measurements start from an empty file
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }
    }

    public void MeasureAccuracy(RenderTexture velocityTex, RenderTexture colorTex)
    {
        // Create the fluid state data
        FluidStateData fluidState = new FluidStateData();

        // Create a temporary Texture2D
        RenderTexture.active = velocityTex;
        Texture2D tempTexture = new Texture2D(velocityTex.width, velocityTex.height, TextureFormat.RGHalf, false);

        // Copy data from RenderTexture to Texture2D
        tempTexture.ReadPixels(new Rect(0, 0, velocityTex.width, velocityTex.height), 0, 0);

        // Get all pixel values
        Color[] pixels = tempTexture.GetPixels();

        // Take a sample of the velocities to save
        // Limit data to every 4th row
        for (int row = 0; row < velocityTex.height; row += 4)
        {
            // Limit data to every 4th column
            for (int col = 0; col < velocityTex.width; col += 4)
            {
                int idx = (row * velocityTex.width) + col;

                if (idx >= pixels.Length) break;

                fluidState.Velocities.Add(new Vector2(pixels[idx].r, pixels[idx].g));
            }
        }

        // Update the temporary Texture2D
        RenderTexture.active = colorTex;
        tempTexture = new Texture2D(colorTex.width, colorTex.height, TextureFormat.RGBAHalf, false);

        // Copy data from RenderTexture to Texture2D
        tempTexture.ReadPixels(new Rect(0, 0, colorTex.width, colorTex.height), 0, 0);

        // Get all pixel values
        pixels = tempTexture.GetPixels();

        // Take a sample of the colors to save
        // Limit data to every 4th row
        for (int row = 0; row < colorTex.height; row += 4)
        {
            // Limit data to every 4th column
            for (int col = 0; col < colorTex.width; col += 4)
            {
                int idx = (row * colorTex.width) + col;

                if (idx >= pixels.Length) break;

                fluidState.Colors.Add(pixels[idx]);
            }
        }

        // Cleanup
        RenderTexture.active = null;
        Destroy(tempTexture);

        // Save the fluid state
        SaveFluidState(fluidState);
    }

    private void SaveFluidState(FluidStateData fluidState)
    {
        // Get the json for the save file
        string json = JsonUtility.ToJson(fluidState, true);

        // Save the velocities to a file
        File.WriteAllText(_filePath, json);
    }
}
