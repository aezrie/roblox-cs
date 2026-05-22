using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class AnimationConstraint : Constraint
{
    // Properties
    public bool IsKinematic { get; set; }
    public float MaxForce { get; set; }
    public float MaxTorque { get; set; }
    public CFrame Transform { get; set; }

}
