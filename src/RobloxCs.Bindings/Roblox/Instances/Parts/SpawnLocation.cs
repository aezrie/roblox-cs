using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class SpawnLocation : Part
{
    // Properties
    public bool AllowTeamChangeOnTouch { get; set; }
    public int Duration { get; set; }
    public bool Enabled { get; set; }
    public bool Neutral { get; set; }
    public BrickColor TeamColor { get; set; }

}
