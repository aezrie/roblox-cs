using System;

namespace Roblox.Instances;

public class PoseBase : Instance
{
    // Properties
    public object? EasingDirection { get; set; } = null!;
    public object? EasingStyle { get; set; } = null!;
    public float Weight { get; set; }

}
