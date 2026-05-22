using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class AudioTextToSpeech : Instance
{
    // Properties
    public bool IsLoaded { get; }
    public bool Looping { get; set; }
    public float Pitch { get; set; }
    public float PlaybackSpeed { get; set; }
    public float Speed { get; set; }
    public string? Text { get; set; } = null!;
    public double TimeLength { get; }
    public double TimePosition { get; set; }
    public string? VoiceId { get; set; } = null!;
    public float Volume { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object Pause() => null!;
    public object Play() => null!;
    public object Unload() => null!;
    public object[] GetWaveformAsync(NumberRange timeRange, int samples) => default!;
    public object LoadAsync() => null!;

    // Events
    public event Action Ended = null!;
    public event Action Looped = null!;
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
