using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class UIGradient : UIComponent
{
    // Properties
    public ColorSequence Color { get; set; }
    public bool Enabled { get; set; }
    public Vector2 Offset { get; set; }
    public float Rotation { get; set; }
    public NumberSequence Transparency { get; set; }

}
