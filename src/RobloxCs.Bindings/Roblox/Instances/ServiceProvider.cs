using System;

namespace Roblox.Instances;

public class ServiceProvider : Instance
{
    // Methods
    public Instance FindService(string? className) => null!;
    public Instance GetService(string? className) => null!;

    // Events
    public event Action Close = null!;
    public event Action<Instance> ServiceAdded = null!;
    public event Action<Instance> ServiceRemoving = null!;
}
