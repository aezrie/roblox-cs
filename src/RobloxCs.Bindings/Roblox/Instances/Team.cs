using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Team : Instance
{
    // Properties
    public bool AutoAssignable { get; set; }
    public BrickColor TeamColor { get; set; }

    // Methods
    public object GetPlayers() => null!;

    // Events
    public event Action<object> PlayerAdded = null!;
    public event Action<object> PlayerRemoved = null!;
}
