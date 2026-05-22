using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Path : Instance
{
    // Properties
    public object? Status { get; } = null!;

    // Methods
    public object[] GetWaypoints() => default!;
    public int CheckOcclusionAsync(int start) => default!;
    public object ComputeAsync(Vector3 start, Vector3 finish) => null!;

    // Events
    public event Action<int> Blocked = null!;
    public event Action<int> Unblocked = null!;
}
