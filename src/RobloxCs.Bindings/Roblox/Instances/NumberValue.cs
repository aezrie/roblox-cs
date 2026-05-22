using System;

namespace Roblox.Instances;

public class NumberValue : ValueBase
{
    // Properties
    public double Value { get; set; }

    // Events
    public event Action<double> Changed = null!;
}
