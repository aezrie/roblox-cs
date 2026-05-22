using System;

namespace Roblox.Instances;

public class NetworkMarker : Instance
{
    // Events
    public event Action Received = null!;
}
