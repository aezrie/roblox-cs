using System;

namespace Roblox.Instances;

public class PluginToolbarButton : Instance
{
    // Properties
    public bool ClickableWhenViewportHidden { get; set; }
    public bool Enabled { get; set; }
    public object? Icon { get; set; } = null!;

}
