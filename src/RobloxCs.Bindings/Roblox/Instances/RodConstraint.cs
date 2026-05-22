using System;

namespace Roblox.Instances;

public class RodConstraint : Constraint
{
    // Properties
    public float CurrentDistance { get; }
    public float Length { get; set; }
    public float LimitAngle0 { get; set; }
    public float LimitAngle1 { get; set; }
    public bool LimitsEnabled { get; set; }
    public float Thickness { get; set; }

}
