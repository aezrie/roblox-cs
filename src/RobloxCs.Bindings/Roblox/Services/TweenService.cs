using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class TweenService : Instance
{
    // Methods
    public object Create(Instance? instance, object? tweenInfo, System.Collections.Generic.Dictionary<string, object> propertyTable) => null!;
    public float GetValue(float alpha, object? easingStyle, object? easingDirection) => default!;
    public void SmoothDamp(object? current, object? target, object? velocity, float smoothTime, object? maxSpeed, object? dt) { }

}
