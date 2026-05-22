using System;

namespace Roblox.Instances;

public class PluginGui : LayerCollector
{
    // Properties
    public string? Title { get; set; } = null!;

    // Methods
    public object BindToClose(Delegate? function = null) => null!;

}
