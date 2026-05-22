using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class AccessoryDescription : Instance
{
    // Properties
    public object? AccessoryType { get; set; } = null!;
    public long AssetId { get; set; }
    public Instance? Instance { get; set; } = null!;
    public bool IsLayered { get; set; }
    public int Order { get; set; }
    public Vector3 Position { get; set; }
    public float Puffiness { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Scale { get; set; }

    // Methods
    public Instance GetAppliedInstance() => null!;

}
