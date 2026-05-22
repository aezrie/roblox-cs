using System;

namespace Roblox.Instances;

public class AudioTremolo : Instance
{
    // Properties
    public bool Bypass { get; set; }
    public float Depth { get; set; }
    public float Duty { get; set; }
    public float Frequency { get; set; }
    public float Shape { get; set; }
    public float Skew { get; set; }
    public float Square { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
