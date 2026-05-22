using System;

namespace Roblox.Instances;

public class VelocityMotor : JointInstance
{
    // Properties
    public float CurrentAngle { get; set; }
    public float DesiredAngle { get; set; }
    public object? Hole { get; set; } = null!;
    public float MaxVelocity { get; set; }

}
