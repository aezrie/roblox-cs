using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Animator : Instance
{
    // Properties
    public bool EvaluationThrottled { get; }
    public bool PreferLodEnabled { get; set; }
    public CFrame RootMotion { get; }
    public float RootMotionWeight { get; }

    // Methods
    public object ApplyJointVelocities(object? motors) => null!;
    public object[] GetPlayingAnimationTracks() => default!;
    public object GetTrackByAnimationId(object? animationId) => null!;
    public object LoadAnimation(object? animation) => null!;
    public object RegisterEvaluationParallelCallback(Delegate? callback) => null!;

    // Events
    public event Action<object> AnimationPlayed = null!;
}
