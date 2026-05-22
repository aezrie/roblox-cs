using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Model : PVInstance
{
    // Properties
    public object? ModelStreamingMode { get; set; } = null!;
    public object? PrimaryPart { get; set; } = null!;
    public CFrame WorldPivot { get; set; }

    // Methods
    public object AddPersistentPlayer(object? playerInstance = null) => null!;
    public void GetBoundingBox() { }
    public Vector3 GetExtentsSize() => default!;
    public object GetPersistentPlayers() => null!;
    public float GetScale() => default!;
    public object MoveTo(Vector3 position) => null!;
    public object RemovePersistentPlayer(object? playerInstance = null) => null!;
    public object ScaleTo(float newScaleFactor) => null!;
    public object TranslateBy(Vector3 delta) => null!;

}
