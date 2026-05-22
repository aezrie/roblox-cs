using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class HandleAdornment : PVAdornment
{
    // Properties
    public object? AdornCullingMode { get; set; } = null!;
    public bool AlwaysOnTop { get; set; }
    public CFrame CFrame { get; set; }
    public Vector3 SizeRelativeOffset { get; set; }
    public int ZIndex { get; set; }

    // Events
    public event Action MouseButton1Down = null!;
    public event Action MouseButton1Up = null!;
    public event Action MouseEnter = null!;
    public event Action MouseLeave = null!;
}
