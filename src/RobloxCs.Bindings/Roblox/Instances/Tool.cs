using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Tool : BackpackItem
{
    // Properties
    public bool CanBeDropped { get; set; }
    public bool Enabled { get; set; }
    public CFrame Grip { get; set; }
    public bool ManualActivationOnly { get; set; }
    public bool RequiresHandle { get; set; }
    public string? ToolTip { get; set; } = null!;

    // Methods
    public object Activate() => null!;
    public object Deactivate() => null!;

    // Events
    public event Action Activated = null!;
    public event Action Deactivated = null!;
    public event Action<object> Equipped = null!;
    public event Action Unequipped = null!;
}
