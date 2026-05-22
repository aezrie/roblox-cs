using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class AudioPlayer : Instance
{
    // Properties
    public object? Asset { get; set; } = null!;
    public bool AutoLoad { get; set; }
    public bool AutoPlay { get; set; }
    public bool IsReady { get; }
    public NumberRange LoopRegion { get; set; }
    public bool Looping { get; set; }
    public NumberRange PlaybackRegion { get; set; }
    public double PlaybackSpeed { get; set; }
    public double TimeLength { get; }
    public double TimePosition { get; set; }
    public float Volume { get; set; }

    // Methods
    public bool Cancel(object? actionId) => default!;
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;
    public object Play(object? atTime) => null!;
    public object Stop(object? atTime) => null!;
    public object[] GetWaveformAsync(NumberRange timeRange, int samples) => default!;

    // Events
    public event Action Ended = null!;
    public event Action Looped = null!;
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
