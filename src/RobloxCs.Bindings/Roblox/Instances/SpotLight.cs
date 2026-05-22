using System;

namespace Roblox.Instances;

public class SpotLight : Light
{
    // Properties
    public float Angle { get; set; }
    public object? Face { get; set; } = null!;
    public float Range { get; set; }

}
