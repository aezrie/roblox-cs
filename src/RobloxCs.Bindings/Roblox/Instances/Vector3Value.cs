using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Vector3Value : ValueBase
{
    // Properties
    public Vector3 Value { get; set; }

    // Events
    public event Action<Vector3> Changed = null!;
}
