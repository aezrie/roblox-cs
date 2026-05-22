using System;

namespace Roblox.Instances;

public class UIAspectRatioConstraint : UIConstraint
{
    // Properties
    public float AspectRatio { get; set; }
    public object? AspectType { get; set; } = null!;
    public object? DominantAxis { get; set; } = null!;

}
