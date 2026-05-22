namespace Roblox.Datatypes;

public struct Vector3
{
    public float X, Y, Z;
    public Vector3(float x, float y, float z) => (X, Y, Z) = (x, y, z);
    public static Vector3 operator +(Vector3 a, Vector3 b) => default;
    public static Vector3 operator -(Vector3 a, Vector3 b) => default;
    public static Vector3 operator *(Vector3 a, float b) => default;
    public static Vector3 operator /(Vector3 a, float b) => default;
}

public struct Vector2
{
    public float X, Y;
    public Vector2(float x, float y) => (X, Y) = (x, y);
}

public struct CFrame
{
    public Vector3 Position;
    public static CFrame LookAt(Vector3 at, Vector3 lookAt) => default;
}

public struct Color3
{
    public float R, G, B;
    public static Color3 FromRGB(int r, int g, int b) => default;
}

public struct UDim
{
    public float Scale;
    public int Offset;
}

public struct UDim2
{
    public UDim X, Y;
}

public struct Rect
{
    public Vector2 Min, Max;
}

public struct NumberRange
{
    public float Min, Max;
}

public struct NumberSequence { }
public struct ColorSequence { }
public struct Ray { }
public struct Faces { }
public struct Axes { }
public struct BrickColor { }
