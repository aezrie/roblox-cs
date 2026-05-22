using System;

namespace Roblox.Instances;

public class UniversalConstraint : Constraint
{
    // Properties
    public bool LimitsEnabled { get; set; }
    public float MaxAngle { get; set; }
    public float Radius { get; set; }
    public float Restitution { get; set; }

}
