using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class CylindricalConstraint : SlidingBallConstraint
{
    // Properties
    public object? AngularActuatorType { get; set; } = null!;
    public bool AngularLimitsEnabled { get; set; }
    public float AngularResponsiveness { get; set; }
    public float AngularRestitution { get; set; }
    public float AngularSpeed { get; set; }
    public float AngularVelocity { get; set; }
    public float CurrentAngle { get; }
    public float InclinationAngle { get; set; }
    public float LowerAngle { get; set; }
    public float MotorMaxAngularAcceleration { get; set; }
    public float MotorMaxTorque { get; set; }
    public bool RotationAxisVisible { get; set; }
    public float ServoMaxTorque { get; set; }
    public float TargetAngle { get; set; }
    public float UpperAngle { get; set; }
    public Vector3 WorldRotationAxis { get; }

}
