using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class MaterialVariant : Instance
{
    // Properties
    public object? AlphaMode { get; set; } = null!;
    public object? CustomPhysicalProperties { get; set; } = null!;
    public float EmissiveStrength { get; set; }
    public Color3 EmissiveTint { get; set; }
    public object? MaterialPattern { get; set; } = null!;
    public float StudsPerTile { get; set; }

}
