using System;

namespace Roblox.Instances;

public class ConfigSnapshot : Object
{
    // Properties
    public object? Error { get; } = null!;
    public bool Outdated { get; }

    // Methods
    public object GetValue(string? key) => null!;
    public object GetValueChangedSignal(string? key) => null!;
    public object Refresh() => null!;

    // Events
    public event Action UpdateAvailable = null!;
}
