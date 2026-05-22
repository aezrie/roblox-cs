using System;

namespace Roblox.Instances;

public class Seat : Part
{
    // Properties
    public bool Disabled { get; set; }
    public object? Occupant { get; } = null!;

    // Methods
    public object Sit(Instance? humanoid) => null!;

}
