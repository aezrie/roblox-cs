using System;

namespace Roblox.Instances;

public class AudioReverb : Instance
{
    // Properties
    public bool Bypass { get; set; }
    public float DecayRatio { get; set; }
    public float DecayTime { get; set; }
    public float Density { get; set; }
    public float Diffusion { get; set; }
    public float DryLevel { get; set; }
    public float EarlyDelayTime { get; set; }
    public float HighCutFrequency { get; set; }
    public float LateDelayTime { get; set; }
    public float LowShelfFrequency { get; set; }
    public float LowShelfGain { get; set; }
    public float ReferenceFrequency { get; set; }
    public float WetLevel { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
