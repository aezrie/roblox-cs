using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class CFrameValue : ValueBase
{
    // Properties
    public CFrame Value { get; set; }

    // Events
    public event Action<CFrame> Changed = null!;
}
