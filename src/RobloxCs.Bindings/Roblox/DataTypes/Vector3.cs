namespace Roblox.Datatypes;

public struct Vector3
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vector3(float x, float y, float z) { X = x; Y = y; Z = z; }

    public float Magnitude => default;
    public Vector3 Unit => default;

    public static Vector3 operator +(Vector3 a, Vector3 b) => default;
    public static Vector3 operator -(Vector3 a, Vector3 b) => default;
    public static Vector3 operator *(Vector3 a, float b) => default;

    public static readonly Vector3 Zero = new(0, 0, 0);
    public static readonly Vector3 One = new(1, 1, 1);
}
