using System;

namespace Roblox.Instances;

public class CylinderHandleAdornment : HandleAdornment
{
    // Properties
    public float Angle { get; set; }
    public float Height { get; set; }
    public float InnerRadius { get; set; }
    public float Radius { get; set; }
    public object? Shading { get; set; } = null!;

}
