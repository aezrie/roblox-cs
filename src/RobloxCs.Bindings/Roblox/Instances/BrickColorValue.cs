using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class BrickColorValue : ValueBase
{
    // Properties
    public BrickColor Value { get; set; }

    // Events
    public event Action<BrickColor> Changed = null!;
}
