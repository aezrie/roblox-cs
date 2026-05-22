using System;

namespace Roblox.Instances;

public class TorsionSpringConstraint : Constraint
{
    // Properties
    public float Coils { get; set; }
    public float CurrentAngle { get; }
    public float Damping { get; set; }
    public bool LimitsEnabled { get; set; }
    public float MaxAngle { get; set; }
    public float MaxTorque { get; set; }
    public float Radius { get; set; }
    public float Restitution { get; set; }
    public float Stiffness { get; set; }

}
