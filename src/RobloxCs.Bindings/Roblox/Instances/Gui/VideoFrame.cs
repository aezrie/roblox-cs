using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class VideoFrame : GuiObject
{
    // Properties
    public bool IsLoaded { get; }
    public bool Looped { get; set; }
    public object? MaximumResolution { get; set; } = null!;
    public bool Playing { get; set; }
    public Vector2 Resolution { get; }
    public float RollOffMaxDistance { get; set; }
    public float RollOffMinDistance { get; set; }
    public object? RollOffMode { get; set; } = null!;
    public double TimeLength { get; }
    public double TimePosition { get; set; }
    public object? Video { get; set; } = null!;
    public string? VideoContent { get; set; } = null!;
    public float Volume { get; set; }

    // Methods
    public object Pause() => null!;
    public object Play() => null!;

    // Events
    public event Action<string> DidLoop = null!;
    public event Action<string> Ended = null!;
    public event Action<string> Loaded = null!;
    public event Action<string> Paused = null!;
    public event Action<string> Played = null!;
}
