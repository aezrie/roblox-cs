using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class TerrainDetail : Instance
{
    // Properties
    public float EmissiveStrength { get; set; }
    public Color3 EmissiveTint { get; set; }
    public object? Face { get; set; } = null!;
    public object? MaterialPattern { get; set; } = null!;
    public float StudsPerTile { get; set; }

}
