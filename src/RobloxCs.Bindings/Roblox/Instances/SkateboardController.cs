using System;

namespace Roblox.Instances;

public class SkateboardController : Controller
{
    // Properties
    public float Steer { get; }
    public float Throttle { get; }

    // Events
    public event Action<string> AxisChanged = null!;
}
