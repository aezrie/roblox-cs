using System;

namespace Roblox.Instances;

public class RTAnimationTracker : Instance
{
    // Events
    public event Action<object, string> TrackerError = null!;
    public event Action<object> TrackerPrompt = null!;
}
