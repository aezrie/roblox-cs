using System;

namespace Roblox.Instances;

public class Controller : Instance
{
    // Methods
    public object BindButton(object? button, string? caption) => null!;
    public bool GetButton(object? button) => default!;
    public object UnbindButton(object? button) => null!;

    // Events
    public event Action<object> ButtonChanged = null!;
}
