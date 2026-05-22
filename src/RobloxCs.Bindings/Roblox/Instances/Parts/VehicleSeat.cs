using System;

namespace Roblox.Instances;

public class VehicleSeat : BasePart
{
    // Properties
    public int AreHingesDetected { get; }
    public bool Disabled { get; set; }
    public bool HeadsUpDisplay { get; set; }
    public float MaxSpeed { get; set; }
    public object? Occupant { get; } = null!;
    public int Steer { get; set; }
    public float SteerFloat { get; set; }
    public int Throttle { get; set; }
    public float ThrottleFloat { get; set; }
    public float Torque { get; set; }
    public float TurnSpeed { get; set; }

    // Methods
    public object Sit(Instance? humanoid) => null!;

}
