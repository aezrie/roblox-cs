using System;

namespace Roblox.Instances;

public class PluginAction : Instance
{
    // Properties
    public string? ActionId { get; } = null!;
    public bool AllowBinding { get; }
    public string? StatusTip { get; } = null!;

}
