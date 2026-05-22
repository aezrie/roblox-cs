using System;

namespace Roblox.Instances;

public class SpringConstraint : Constraint
{
    // Properties
    public float Coils { get; set; }
    public float CurrentLength { get; }
    public float Damping { get; set; }
    public float FreeLength { get; set; }
    public bool LimitsEnabled { get; set; }
    public float MaxForce { get; set; }
    public float MaxLength { get; set; }
    public float MinLength { get; set; }
    public float Radius { get; set; }
    public float Stiffness { get; set; }
    public float Thickness { get; set; }

}
