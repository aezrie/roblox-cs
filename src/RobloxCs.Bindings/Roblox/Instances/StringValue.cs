using System;

namespace Roblox.Instances;

public class StringValue : ValueBase
{
    // Properties
    public string? Value { get; set; } = null!;

    // Events
    public event Action<string> Changed = null!;
}
