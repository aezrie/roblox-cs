using System;

namespace Roblox.Instances;

public class Motor : JointInstance
{
    // Properties
    public float CurrentAngle { get; set; }
    public float DesiredAngle { get; set; }
    public float MaxVelocity { get; set; }

    // Methods
    public object SetDesiredAngle(float value) => null!;

}
