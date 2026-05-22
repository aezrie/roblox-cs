using System;

namespace Roblox.Instances;

public class GroundController : ControllerBase
{
    // Properties
    public float AccelerationLean { get; set; }
    public float AccelerationTime { get; set; }
    public float BalanceMaxTorque { get; set; }
    public float BalanceSpeed { get; set; }
    public float DecelerationTime { get; set; }
    public float Friction { get; set; }
    public float FrictionWeight { get; set; }
    public float GroundOffset { get; set; }
    public float StandForce { get; set; }
    public float StandSpeed { get; set; }
    public float TurnSpeedFactor { get; set; }

}
