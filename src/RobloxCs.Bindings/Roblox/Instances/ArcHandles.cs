using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ArcHandles : HandlesBase
{
    // Properties
    public Axes Axes { get; set; }

    // Events
    public event Action<object> MouseButton1Down = null!;
    public event Action<object> MouseButton1Up = null!;
    public event Action<object, float, float> MouseDrag = null!;
    public event Action<object> MouseEnter = null!;
    public event Action<object> MouseLeave = null!;
}
