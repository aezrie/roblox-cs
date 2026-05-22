using System;

namespace Roblox.Instances;

public class AudioChorus : Instance
{
    // Properties
    public bool Bypass { get; set; }
    public float Depth { get; set; }
    public float Mix { get; set; }
    public float Rate { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
