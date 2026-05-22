using System;

namespace Roblox.Instances;

public class AudioAnalyzer : Instance
{
    // Properties
    public float PeakLevel { get; }
    public float RmsLevel { get; }
    public bool SpectrumEnabled { get; set; }
    public object? WindowSize { get; set; } = null!;

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;
    public object[] GetSpectrum() => default!;

    // Events
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
