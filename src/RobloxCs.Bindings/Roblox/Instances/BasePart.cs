namespace Roblox.Instances;
public class BasePart : Instance
{
    public Vector3 Position { get; set; }
    public Vector3 Size { get; set; }
    public CFrame CFrame { get; set; }
    public bool Anchored { get; set; }
    public bool CanCollide { get; set; }
}
