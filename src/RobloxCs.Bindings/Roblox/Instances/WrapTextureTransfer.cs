using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class WrapTextureTransfer : Instance
{
    // Properties
    public string? ReferenceCageMeshContent { get; set; } = null!;
    public Vector2 UVMaxBound { get; set; }
    public Vector2 UVMinBound { get; set; }

}
