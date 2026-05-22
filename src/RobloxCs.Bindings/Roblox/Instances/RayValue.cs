using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class RayValue : ValueBase
{
    // Properties
    public Ray Value { get; set; }

    // Events
    public event Action<Ray> Changed = null!;
}
