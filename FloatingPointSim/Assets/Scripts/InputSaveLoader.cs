using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public List<InputData> Inputs = new List<InputData>();
}

public class InputSaveLoader : MonoBehaviour
{
    public enum SaveLoadState
    {
        None,
        Saving,
        Loading,
    }
    [Header("Inputs Save/Load Settings")]
    [SerializeField] private SaveLoadState _saveLoadState = SaveLoadState.None;
    public SaveLoadState GetState() { return _saveLoadState; }

    [SerializeField] private string _customFilename = string.Empty;

    // Save/Load variables
    private const string _defaultFilename = "SavedInputs";
    private const float _saveFrequency = 1.0f;

    private string _filePath = string.Empty;

    private List<InputData> _saveLoadInputs = new List<InputData>();

    private void Start()
    {
        if (_saveLoadState != SaveLoadState.None)
        {
            // Create the directory, if needed
            string directory = Path.Combine(Application.persistentDataPath, "Data");
            Directory.CreateDirectory(directory);

            // Set file path and create the Data directory if needed
            string filename = ((_customFilename == string.Empty) ? _defaultFilename : _customFilename) + ".json";
            _filePath = Path.Combine(directory, filename);
        }

        switch (_saveLoadState)
        {
            case SaveLoadState.Saving:
                {
                    // Start saving coroutine
                    StartCoroutine(SaveInputsCoroutine());

                    break;
                }
            case SaveLoadState.Loading:
                {
                    // Load inputs into queue
                    LoadInputs();

                    break;
                }
            default:
                break;
        }
    }

    private void OnDestroy()
    {
        // Do a final save of the last inputs
        if (_saveLoadState == SaveLoadState.Saving)
        {
            StopCoroutine(nameof(SaveInputsCoroutine));
            SaveInputs();
        }
    }

    public void SaveInput(InputData input)
    {
        _saveLoadInputs.Add(input);
    }

    private IEnumerator SaveInputsCoroutine()
    {
        while (_saveLoadState == SaveLoadState.Saving)
        {
            // Wait before saving inputs
            yield return new WaitForSeconds(_saveFrequency);

            SaveInputs();
        }
    }

    private void SaveInputs()
    {
        // Check if there are inputs to save
        if (_saveLoadInputs.Count == 0) return;

        // Get previous saved inputs
        SaveData saveData = new SaveData();
        if (File.Exists(_filePath))
        {
            string prevInputs = File.ReadAllText(_filePath);
            saveData = JsonUtility.FromJson<SaveData>(prevInputs);
        }

        // Append new inputs
        saveData.Inputs.AddRange(_saveLoadInputs);

        // Get the json for the save file
        string json = JsonUtility.ToJson(saveData, true);

        // Save the inputs to a file
        File.WriteAllText(_filePath, json);

        // Clear the list of inputs
        _saveLoadInputs.Clear();
    }

    private void LoadInputs()
    {
        // Check if the save file exists
        if (!File.Exists(_filePath)) return;

        // Get the inputs from the save file
        string json = File.ReadAllText(_filePath);
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);

        // Add all loaded inputs to be queued
        _saveLoadInputs.AddRange(saveData.Inputs);
    }

    public List<InputData> GetQueueableInputs(int executionStep)
    {
        // Check if there are inputs to be queued
        if (_saveLoadInputs.Count == 0) return new List<InputData>();

        // Get the inputs for the current (or a previous) step
        List<InputData> inputs = _saveLoadInputs
            .Where(input => input.ExecutionStep <= executionStep)
            .ToList();

        // Remove these inputs from the queue
        _saveLoadInputs.RemoveAll(input => inputs.Contains(input));

        return inputs;
    }
}
