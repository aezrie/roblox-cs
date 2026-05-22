using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class StudioAttachment : Instance
{
    // Properties
    public bool AutoHideParent { get; set; }
    public bool IsArrowVisible { get; set; }
    public Vector2 Offset { get; set; }
    public Vector2 SourceAnchorPoint { get; set; }
    public Vector2 TargetAnchorPoint { get; set; }

}
