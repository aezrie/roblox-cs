using System;

namespace Roblox.Instances;

public class BindableFunction : Instance
{
    // Methods
    public object[] Invoke(object[]? arguments) => default!;

    // Callbacks
    public Func<object[], object[]>? OnInvoke { get; set; }

}
