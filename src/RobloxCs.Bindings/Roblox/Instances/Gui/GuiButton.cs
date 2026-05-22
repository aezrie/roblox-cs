using System;

namespace Roblox.Instances;

public class GuiButton : GuiObject
{
    // Properties
    public bool AutoButtonColor { get; set; }
    public object? HoverHapticEffect { get; set; } = null!;
    public bool Modal { get; set; }
    public object? PressHapticEffect { get; set; } = null!;
    public bool Selected { get; set; }
    public object? Style { get; set; } = null!;

    // Events
    public event Action<object, int> Activated = null!;
    public event Action MouseButton1Click = null!;
    public event Action<int, int> MouseButton1Down = null!;
    public event Action<int, int> MouseButton1Up = null!;
    public event Action MouseButton2Click = null!;
    public event Action<int, int> MouseButton2Down = null!;
    public event Action<int, int> MouseButton2Up = null!;
    public event Action<object> SecondaryActivated = null!;
}
