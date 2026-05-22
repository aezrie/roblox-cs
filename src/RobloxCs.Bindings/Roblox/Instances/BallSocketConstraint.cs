using System;

namespace Roblox.Instances;

public class BallSocketConstraint : Constraint
{
    // Properties
    public bool LimitsEnabled { get; set; }
    public float MaxFrictionTorque { get; set; }
    public float Radius { get; set; }
    public float Restitution { get; set; }
    public bool TwistLimitsEnabled { get; set; }
    public float TwistLowerAngle { get; set; }
    public float TwistUpperAngle { get; set; }
    public float UpperAngle { get; set; }

}
