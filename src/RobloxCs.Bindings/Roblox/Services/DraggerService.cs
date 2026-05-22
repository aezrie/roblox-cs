using System;
using Roblox.Datatypes;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class DraggerService : Instance
{
    // Properties
    public bool AlignDraggedObjects { get; set; }
    public bool AngleSnapEnabled { get; set; }
    public float AngleSnapIncrement { get; set; }
    public bool AnimateHover { get; set; }
    public bool CollisionsEnabled { get; set; }
    public object? DraggerCoordinateSpace { get; set; } = null!;
    public object? DraggerMovementMode { get; set; } = null!;
    public Color3 GeometrySnapColor { get; set; }
    public float HoverAnimateFrequency { get; set; }
    public float HoverThickness { get; set; }
    public bool JointsEnabled { get; set; }
    public bool LinearSnapEnabled { get; set; }
    public float LinearSnapIncrement { get; set; }
    public bool ShowHover { get; set; }
    public bool ShowPivotIndicator { get; set; }

}
