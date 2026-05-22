using System;

namespace Roblox.Instances;

public class AnimationTrack : Instance
{
    // Properties
    public object? Animation { get; } = null!;
    public bool IsPlaying { get; }
    public float Length { get; }
    public bool Looped { get; set; }
    public object? Priority { get; set; } = null!;
    public float Speed { get; }
    public float TimePosition { get; set; }
    public float WeightCurrent { get; }
    public float WeightTarget { get; }

    // Methods
    public object AdjustSpeed(float speed = 1) => null!;
    public object AdjustWeight(float weight = 1, float fadeTime = default) => null!;
    public object GetMarkerReachedSignal(string? name) => null!;
    public object GetParameter(string? key) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetParameterDefaults() => default!;
    public Instance GetTargetInstance(string? name) => null!;
    public object[] GetTargetNames() => default!;
    public double GetTimeOfKeyframe(string? keyframeName) => default!;
    public object Play(float fadeTime = default, float weight = 1, float speed = 1) => null!;
    public object SetParameter(string? key, object? value) => null!;
    public object SetTargetInstance(string? name, Instance? target) => null!;
    public object Stop(float fadeTime = default) => null!;

    // Events
    public event Action DidLoop = null!;
    public event Action Ended = null!;
    public event Action<string> KeyframeReached = null!;
    public event Action Stopped = null!;
}
