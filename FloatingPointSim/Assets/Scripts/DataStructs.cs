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

public struct InputData
{
    public Vector2 ForceOrigin;
    public Vector2 ForceVector;

    public uint ExecutionStep;

    public bool IsStirInput;

    public InputData(Vector2 forceOrigin, Vector2 forceVector, uint executionStep, bool isStirInput)
    {
        ForceOrigin = forceOrigin;
        ForceVector = forceVector;

        ExecutionStep = executionStep;

        IsStirInput = isStirInput;
    }

    public ForceData GetForceData()
    {
        return new ForceData(ForceOrigin, ForceVector);
    }
}
