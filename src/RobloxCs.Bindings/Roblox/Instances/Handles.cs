using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Handles : HandlesBase
{
    // Properties
    public Faces Faces { get; set; }
    public object? Style { get; set; } = null!;

    // Events
    public event Action<object> MouseButton1Down = null!;
    public event Action<object> MouseButton1Up = null!;
    public event Action<object, float> MouseDrag = null!;
    public event Action<object> MouseEnter = null!;
    public event Action<object> MouseLeave = null!;
}
