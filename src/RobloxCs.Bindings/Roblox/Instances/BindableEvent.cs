using System;

namespace Roblox.Instances;

public class BindableEvent : Instance
{
    // Methods
    public object Fire(object[]? arguments) => null!;

    // Events
    public event Action<object[]> Event = null!;
}
