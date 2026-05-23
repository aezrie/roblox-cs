namespace Roblox.Datatypes;

[RobloxStruct]
public struct Vector3
{
    public float X, Y, Z;
    public Vector3(float x, float y, float z) => (X, Y, Z) = (x, y, z);
    public static Vector3 operator +(Vector3 a, Vector3 b) => default;
    public static Vector3 operator -(Vector3 a, Vector3 b) => default;
    public static Vector3 operator *(Vector3 a, float b) => default;
    public static Vector3 operator /(Vector3 a, float b) => default;
}

[RobloxStruct]
public struct Vector2
{
    public float X, Y;
    public Vector2(float x, float y) => (X, Y) = (x, y);
}

[RobloxStruct]
public struct CFrame
{
    public Vector3 Position;
    public static CFrame LookAt(Vector3 at, Vector3 lookAt) => default;
}

[RobloxStruct]
public struct Color3
{
    public float R, G, B;
    public static Color3 FromRGB(int r, int g, int b) => default;
}

[RobloxStruct]
public struct UDim
{
    public float Scale;
    public int Offset;
}

[RobloxStruct]
public struct UDim2
{
    public UDim X, Y;
}

[RobloxStruct]
public struct Rect
{
    public Vector2 Min, Max;
}

[RobloxStruct]
public struct NumberRange
{
    public float Min, Max;
}

[RobloxStruct] public struct NumberSequence { }
[RobloxStruct] public struct ColorSequence { }
[RobloxStruct] public struct Ray { }
[RobloxStruct] public struct Faces { }
[RobloxStruct] public struct Axes { }
[RobloxStruct] public struct BrickColor { }
