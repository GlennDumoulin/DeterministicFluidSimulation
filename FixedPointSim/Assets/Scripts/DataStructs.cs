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
public struct FixedPoint
{
    // Number of fractional bits
    private const int FRACTIONAL_BITS = 22;

    // Scaling factor (2^22)
    private const int SCALING_FACTOR = 1 << FRACTIONAL_BITS;

    // Internal representation as an integer
    public int RawValue { get; private set; }

    // Constructor to create a FixedPoint from an integer
    public FixedPoint(int rawValue)
    {
        RawValue = rawValue << FRACTIONAL_BITS;
    }

    // Constructor to create a FixedPoint from a float or double
    public FixedPoint(float value)
    {
        RawValue = (int)(value * SCALING_FACTOR);
    }

    // Accessor to convert back to float
    public float ToFloat()
    {
        return (float)RawValue / SCALING_FACTOR;
    }

    // Convert float to fixed-point and back
    public static float FixedFloat(float value)
    {
        FixedPoint tmp = new FixedPoint(value);
        return tmp.ToFloat();
    }

    // Addition
    public static FixedPoint operator +(FixedPoint a, FixedPoint b)
    {
        return new FixedPoint { RawValue = a.RawValue + b.RawValue };
    }
    public static FixedPoint operator +(FixedPoint a, int b)
    {
        FixedPoint tempB = new FixedPoint(b);
        return a + tempB;
    }
    public static FixedPoint operator +(int a, FixedPoint b)
    {
        FixedPoint tempA = new FixedPoint(a);
        return tempA + b;
    }

    // Subtraction
    public static FixedPoint operator -(FixedPoint a, FixedPoint b)
    {
        return new FixedPoint { RawValue = a.RawValue - b.RawValue };
    }
    public static FixedPoint operator -(FixedPoint a, int b)
    {
        FixedPoint tempB = new FixedPoint(b);
        return a - tempB;
    }
    public static FixedPoint operator -(int a, FixedPoint b)
    {
        FixedPoint tempA = new FixedPoint(a);
        return tempA - b;
    }

    // Multiplication
    public static FixedPoint operator *(FixedPoint a, FixedPoint b)
    {
        return new FixedPoint { RawValue = (a.RawValue * b.RawValue) >> FRACTIONAL_BITS };
    }
    public static FixedPoint operator *(FixedPoint a, int b)
    {
        FixedPoint tempB = new FixedPoint(b);
        return a * tempB;
    }
    public static FixedPoint operator *(int a, FixedPoint b)
    {
        FixedPoint tempA = new FixedPoint(a);
        return tempA * b;
    }

    // Division
    public static FixedPoint operator /(FixedPoint a, FixedPoint b)
    {
        return new FixedPoint { RawValue = (a.RawValue << FRACTIONAL_BITS) / b.RawValue };
    }
    public static FixedPoint operator /(FixedPoint a, int b)
    {
        FixedPoint tempB = new FixedPoint(b);
        return a / tempB;
    }
    public static FixedPoint operator /(int a, FixedPoint b)
    {
        FixedPoint tempA = new FixedPoint(a);
        return tempA / b;
    }

    // Square Root
    public FixedPoint Sqrt()
    {
        if (RawValue < 0) // No square root for negative numbers
            throw new System.ArgumentOutOfRangeException("Cannot calculate square root of a negative number.");

        if (RawValue == 0) // Quick exit for 0
            return new FixedPoint(0);

        int x = RawValue;
        int result = RawValue;

        // Newton-Raphson Iteration
        for (int i = 0; i < 10; ++i) // 10 iterations for precision
        {
            result = (result + (x * SCALING_FACTOR) / result) >> 1;
        }

        return new FixedPoint { RawValue = result };
    }

    // Negation
    public static FixedPoint operator -(FixedPoint a)
    {
        FixedPoint temp = new FixedPoint();
        temp.RawValue = -a.RawValue;
        return temp;
    }

    public override string ToString()
    {
        return $"{RawValue}";
    }
}

[System.Serializable]
public struct FixedVector2
{
    public FixedPoint X;
    public FixedPoint Y;

    // Constructor
    public FixedVector2(FixedPoint x, FixedPoint y)
    {
        X = x;
        Y = y;
    }

    // Constructor from floats
    public FixedVector2(float x, float y)
        : this(new FixedPoint(x), new FixedPoint(y))
    {}

    public FixedVector2(Vector2 v)
        : this(v.x, v.y)
    {}

    // Accessor to convert back to floats
    public Vector2 ToFloats()
    {
        return new Vector2(
            X.ToFloat(),
            Y.ToFloat()
        );
    }

    // Convert floats to fixed-point and back
    public static Vector2 FixedFloats(Vector2 value)
    {
        FixedVector2 tmp = new FixedVector2(value);
        return tmp.ToFloats();
    }

    // Magnitude
    public FixedPoint Magnitude()
    {
        return SqrMagnitude().Sqrt();
    }

    // Squared Magnitude (avoids costly square root)
    public FixedPoint SqrMagnitude()
    {
        return X * X + Y * Y;
    }

    // Normalization
    public FixedVector2 Normalize()
    {
        FixedPoint mag = Magnitude();
        return mag.RawValue == 0 ? new FixedVector2(0, 0) : new FixedVector2(X / mag, Y / mag);
    }

    // Addition
    public static FixedVector2 operator +(FixedVector2 a, FixedVector2 b)
    {
        return new FixedVector2(a.X + b.X, a.Y + b.Y);
    }

    // Subtraction
    public static FixedVector2 operator -(FixedVector2 a, FixedVector2 b)
    {
        return new FixedVector2(a.X - b.X, a.Y - b.Y);
    }

    // Scalar Multiplication
    public static FixedVector2 operator *(FixedVector2 a, FixedPoint scalar)
    {
        return new FixedVector2(a.X * scalar, a.Y * scalar);
    }
    public static FixedVector2 operator *(FixedPoint scalar, FixedVector2 a)
    {
        return new FixedVector2(a.X * scalar, a.Y * scalar);
    }

    // Scalar Division
    public static FixedVector2 operator /(FixedVector2 a, FixedPoint scalar)
    {
        return new FixedVector2(a.X / scalar, a.Y / scalar);
    }
    public static FixedVector2 operator /(FixedVector2 a, int scalar)
    {
        return new FixedVector2(a.X / scalar, a.Y / scalar);
    }

    public override string ToString()
    {
        return $"[{X.RawValue}, {Y.RawValue}]";
    }
}
