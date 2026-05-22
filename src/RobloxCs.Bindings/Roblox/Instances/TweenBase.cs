using System;

namespace Roblox.Instances;

public class TweenBase : Instance
{
    // Properties
    public object? PlaybackState { get; } = null!;

    // Methods
    public object Cancel() => null!;
    public object Pause() => null!;
    public object Play() => null!;

    // Events
    public event Action<object> Completed = null!;
}
