namespace Roblox.Datatypes;

public struct CFrame
{
    public Vector3 Position { get; set; }
    public Vector3 LookVector { get; }
    public Vector3 RightVector { get; }
    public Vector3 UpVector { get; }

    public CFrame(float x, float y, float z) { }
    public CFrame(Vector3 position) { }

    public static CFrame operator *(CFrame a, CFrame b) => default;
}
