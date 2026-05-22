using System;

namespace Roblox.Instances;

public class AudioDeviceOutput : Instance
{
    // Properties
    public object? Player { get; set; } = null!;

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
