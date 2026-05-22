using System;

namespace Roblox.Instances;

public class Object
{
    // Properties
    public string? ClassName { get; } = null!;

    // Methods
    public object GetPropertyChangedSignal(string? property) => null!;
    public bool IsA(string? className) => default!;

    // Events
    public event Action<string> Changed = null!;
}
