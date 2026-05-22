using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Sound : Instance
{
    // Properties
    public bool AcousticSimulationEnabled { get; set; }
    public bool IsLoaded { get; }
    public NumberRange LoopRegion { get; set; }
    public bool Looped { get; set; }
    public bool PlayOnRemove { get; set; }
    public double PlaybackLoudness { get; }
    public NumberRange PlaybackRegion { get; set; }
    public bool PlaybackRegionsEnabled { get; set; }
    public float PlaybackSpeed { get; set; }
    public bool Playing { get; set; }
    public float RollOffMaxDistance { get; set; }
    public float RollOffMinDistance { get; set; }
    public object? RollOffMode { get; set; } = null!;
    public object? SoundGroup { get; set; } = null!;
    public object? SoundId { get; set; } = null!;
    public double TimeLength { get; }
    public double TimePosition { get; set; }
    public float Volume { get; set; }

    // Methods
    public object Pause() => null!;
    public object Play() => null!;
    public object Resume() => null!;
    public object Stop() => null!;

    // Events
    public event Action<string, int> DidLoop = null!;
    public event Action<string> Ended = null!;
    public event Action<string> Loaded = null!;
    public event Action<string> Paused = null!;
    public event Action<string> Played = null!;
    public event Action<string> Resumed = null!;
    public event Action<string> Stopped = null!;
}
