using System;

namespace Roblox.Instances;

public class SensorBase : Instance
{
    // Properties
    public object? UpdateType { get; set; } = null!;

    // Events
    public event Action OnSensorOutputChanged = null!;
}
