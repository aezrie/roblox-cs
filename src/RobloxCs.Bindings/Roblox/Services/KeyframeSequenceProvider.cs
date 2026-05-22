using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class KeyframeSequenceProvider : Instance
{
    // Methods
    public object RegisterActiveKeyframeSequence(Instance? keyframeSequence) => null!;
    public object RegisterKeyframeSequence(Instance? keyframeSequence) => null!;
    public Instance GetAnimationsAsync(long userId) => null!;
    public Instance GetKeyframeSequenceAsync(object? assetId) => null!;

}
