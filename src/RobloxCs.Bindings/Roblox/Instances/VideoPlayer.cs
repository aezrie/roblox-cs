using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class VideoPlayer : Instance
{
    // Properties
    public bool IsLoaded { get; }
    public bool IsPlaying { get; }
    public bool Looping { get; set; }
    public object? MaximumResolution { get; set; } = null!;
    public float PlaybackSpeed { get; set; }
    public Vector2 Resolution { get; }
    public double TimeLength { get; }
    public double TimePosition { get; set; }
    public string? VideoContent { get; set; } = null!;
    public float Volume { get; set; }

    // Methods
    public object GetConnectedWires(string? pin) => null!;
    public object[] GetInputPins() => default!;
    public object[] GetOutputPins() => default!;
    public object Pause() => null!;
    public object Play() => null!;
    public object Unload() => null!;
    public object LoadAsync() => null!;

    // Events
    public event Action DidEnd = null!;
    public event Action DidLoop = null!;
    public event Action<object> PlayFailed = null!;
    public event Action<bool, string, object, Instance> WiringChanged = null!;
}
