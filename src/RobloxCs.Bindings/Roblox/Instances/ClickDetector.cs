using System;

namespace Roblox.Instances;

public class ClickDetector : Instance
{
    // Properties
    public object? CursorIcon { get; set; } = null!;
    public string? CursorIconContent { get; set; } = null!;
    public float MaxActivationDistance { get; set; }

    // Events
    public event Action<object> MouseClick = null!;
    public event Action<object> MouseHoverEnter = null!;
    public event Action<object> MouseHoverLeave = null!;
    public event Action<object> RightMouseClick = null!;
}
