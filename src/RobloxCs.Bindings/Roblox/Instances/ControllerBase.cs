using System;

namespace Roblox.Instances;

public class ControllerBase : Instance
{
    // Properties
    public bool Active { get; }
    public bool BalanceRigidityEnabled { get; set; }
    public float MoveSpeedFactor { get; set; }

}
