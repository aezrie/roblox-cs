using System;

namespace Roblox.Instances;

public class ConeHandleAdornment : HandleAdornment
{
    // Properties
    public float Height { get; set; }
    public bool Hollow { get; set; }
    public float Radius { get; set; }
    public object? Shading { get; set; } = null!;

}
