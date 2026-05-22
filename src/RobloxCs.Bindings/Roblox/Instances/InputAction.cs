using System;

namespace Roblox.Instances;

public class InputAction : Instance
{
    // Properties
    public bool Enabled { get; set; }
    public object? Type { get; set; } = null!;

    // Methods
    public object Fire(object? state) => null!;
    public object GetState() => null!;

    // Events
    public event Action Pressed = null!;
    public event Action Released = null!;
    public event Action<object> StateChanged = null!;
}
