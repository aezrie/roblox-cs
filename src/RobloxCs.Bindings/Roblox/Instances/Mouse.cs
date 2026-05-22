using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Mouse : Instance
{
    // Properties
    public CFrame Hit { get; }
    public object? Icon { get; set; } = null!;
    public string? IconContent { get; set; } = null!;
    public CFrame Origin { get; }
    public object? Target { get; } = null!;
    public Instance? TargetFilter { get; set; } = null!;
    public object? TargetSurface { get; } = null!;
    public Ray UnitRay { get; }
    public int ViewSizeX { get; }
    public int ViewSizeY { get; }
    public int X { get; }
    public int Y { get; }

    // Events
    public event Action Button1Down = null!;
    public event Action Button1Up = null!;
    public event Action Button2Down = null!;
    public event Action Button2Up = null!;
    public event Action Idle = null!;
    public event Action Move = null!;
    public event Action WheelBackward = null!;
    public event Action WheelForward = null!;
}
