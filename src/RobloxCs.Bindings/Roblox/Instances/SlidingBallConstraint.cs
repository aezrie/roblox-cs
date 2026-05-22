using System;

namespace Roblox.Instances;

public class SlidingBallConstraint : Constraint
{
    // Properties
    public object? ActuatorType { get; set; } = null!;
    public float CurrentPosition { get; }
    public bool LimitsEnabled { get; set; }
    public float LinearResponsiveness { get; set; }
    public float LowerLimit { get; set; }
    public float MotorMaxAcceleration { get; set; }
    public float MotorMaxForce { get; set; }
    public float Restitution { get; set; }
    public float ServoMaxForce { get; set; }
    public float Size { get; set; }
    public float Speed { get; set; }
    public float TargetPosition { get; set; }
    public float UpperLimit { get; set; }
    public float Velocity { get; set; }

}
