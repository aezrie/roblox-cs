using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class AnimationClipProvider : Instance
{
    // Methods
    public object RegisterActiveAnimationClip(object? animationClip) => null!;
    public object RegisterAnimationClip(object? animationClip) => null!;
    public object GetAnimationClipAsync(object? assetId) => null!;
    public Instance GetAnimationsAsync(long userId) => null!;
    public object GetClipEvaluatorAsync(object? assetId) => null!;

}
