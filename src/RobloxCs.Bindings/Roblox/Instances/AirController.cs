using System;

namespace Roblox.Instances;

public class AirController : ControllerBase
{
    // Properties
    public float BalanceMaxTorque { get; set; }
    public float BalanceSpeed { get; set; }
    public bool MaintainAngularMomentum { get; set; }
    public bool MaintainLinearMomentum { get; set; }
    public float MoveMaxForce { get; set; }
    public float TurnMaxTorque { get; set; }
    public float TurnSpeedFactor { get; set; }

}
