using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Color3Value : ValueBase
{
    // Properties
    public Color3 Value { get; set; }

    // Events
    public event Action<Color3> Changed = null!;
}
