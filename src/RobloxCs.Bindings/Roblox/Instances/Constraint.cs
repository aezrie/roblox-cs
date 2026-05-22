using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Constraint : Instance
{
    // Properties
    public bool Active { get; }
    public object? Attachment0 { get; set; } = null!;
    public object? Attachment1 { get; set; } = null!;
    public BrickColor Color { get; set; }
    public bool Enabled { get; set; }
    public bool Visible { get; set; }

}
