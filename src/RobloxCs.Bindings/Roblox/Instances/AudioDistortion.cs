using System;

namespace Roblox.Instances;

public class AudioDistortion : Instance
{
    // Properties
    public bool Bypass { get; set; }
    public float Level { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
