using System;

namespace Roblox.Instances;

public class AnimationClip : Instance
{
    // Properties
    public float Length { get; }
    public bool Loop { get; set; }
    public object? Priority { get; set; } = null!;

}
