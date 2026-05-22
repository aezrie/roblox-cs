using System;

namespace Roblox.Instances;

public class SurfaceGuiBase : LayerCollector
{
    // Properties
    public bool Active { get; set; }
    public Instance? Adornee { get; set; } = null!;
    public object? Face { get; set; } = null!;

}
