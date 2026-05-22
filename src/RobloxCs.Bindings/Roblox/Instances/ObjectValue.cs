using System;

namespace Roblox.Instances;

public class ObjectValue : ValueBase
{
    // Properties
    public Instance? Value { get; set; } = null!;

    // Events
    public event Action<Instance> Changed = null!;
}
