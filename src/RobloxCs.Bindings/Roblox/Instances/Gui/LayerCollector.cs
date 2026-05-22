using System;

namespace Roblox.Instances;

public abstract class LayerCollector : GuiBase2d
{
    // Properties
    public bool Enabled { get; set; }
    public bool ResetOnSpawn { get; set; }
    public object? ZIndexBehavior { get; set; } = null!;

}
