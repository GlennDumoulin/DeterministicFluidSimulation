using System.Collections.Generic;
using UnityEngine;

public struct ForceData
{
    public Vector2 ForceOrigin;
    public Vector2 ForceVector;

    public ForceData(Vector2 forceOrigin, Vector2 forceVector)
    {
        ForceOrigin = forceOrigin;
        ForceVector = forceVector;
    }
}

[System.Serializable]
public struct InputData
{
    public Vector2 ForceOrigin;
    public Vector2 ForceVector;

    public int ExecutionStep;
    public int ClientIdx;

    public bool IsStirInput;

    public InputData(Vector2 forceOrigin, Vector2 forceVector, int executionStep, int clientIdx, bool isStirInput)
    {
        ForceOrigin = forceOrigin;
        ForceVector = forceVector;

        ExecutionStep = executionStep;
        ClientIdx = clientIdx;

        IsStirInput = isStirInput;
    }

    public ForceData GetForceData()
    {
        return new ForceData(ForceOrigin, ForceVector);
    }
}

[System.Serializable]
public class SaveData
{
    public List<InputData> Inputs = new List<InputData>();
}
