using System;

namespace Roblox.Instances;

public class HingeConstraint : Constraint
{
    // Properties
    public object? ActuatorType { get; set; } = null!;
    public float AngularResponsiveness { get; set; }
    public float AngularSpeed { get; set; }
    public float AngularVelocity { get; set; }
    public float CurrentAngle { get; }
    public bool LimitsEnabled { get; set; }
    public float LowerAngle { get; set; }
    public float MotorMaxAcceleration { get; set; }
    public float MotorMaxTorque { get; set; }
    public float Radius { get; set; }
    public float Restitution { get; set; }
    public float ServoMaxTorque { get; set; }
    public float TargetAngle { get; set; }
    public float UpperAngle { get; set; }

}
