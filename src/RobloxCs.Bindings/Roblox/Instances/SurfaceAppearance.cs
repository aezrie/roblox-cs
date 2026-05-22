using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class SurfaceAppearance : Instance
{
    // Properties
    public object? AlphaMode { get; set; } = null!;
    public Color3 Color { get; set; }
    public float EmissiveStrength { get; set; }
    public Color3 EmissiveTint { get; set; }
    public object? ResampleMode { get; set; } = null!;

}
