using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class UIPageLayout : UIGridStyleLayout
{
    // Properties
    public bool Animated { get; set; }
    public bool Circular { get; set; }
    public object? CurrentPage { get; } = null!;
    public object? EasingDirection { get; set; } = null!;
    public object? EasingStyle { get; set; } = null!;
    public bool GamepadInputEnabled { get; set; }
    public UDim Padding { get; set; }
    public bool ScrollWheelInputEnabled { get; set; }
    public bool TouchInputEnabled { get; set; }
    public float TweenTime { get; set; }

    // Methods
    public object JumpTo(Instance? page) => null!;
    public object JumpToIndex(int index) => null!;
    public object Next() => null!;
    public object Previous() => null!;

    // Events
    public event Action<Instance> PageEnter = null!;
    public event Action<Instance> PageLeave = null!;
    public event Action<Instance> Stopped = null!;
}
