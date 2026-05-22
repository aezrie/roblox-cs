using System;

namespace Roblox.Instances;

public class BoolValue : ValueBase
{
    // Properties
    public bool Value { get; set; }

    // Events
    public event Action<bool> Changed = null!;
}
