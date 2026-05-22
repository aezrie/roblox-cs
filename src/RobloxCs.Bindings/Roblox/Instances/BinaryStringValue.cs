using System;

namespace Roblox.Instances;

public class BinaryStringValue : ValueBase
{
    // Events
    public event Action<string> Changed = null!;
}
