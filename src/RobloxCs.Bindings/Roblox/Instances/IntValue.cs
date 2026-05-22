using System;

namespace Roblox.Instances;

public class IntValue : ValueBase
{
    // Properties
    public long Value { get; set; }

    // Events
    public event Action<long> Changed = null!;
}
