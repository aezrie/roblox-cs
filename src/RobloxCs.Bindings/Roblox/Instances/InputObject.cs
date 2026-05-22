using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class InputObject : Instance
{
    // Properties
    public Vector3 Delta { get; set; }
    public object? KeyCode { get; set; } = null!;
    public Vector3 Position { get; set; }
    public object? UserInputState { get; set; } = null!;
    public object? UserInputType { get; set; } = null!;

    // Methods
    public bool IsModifierKeyDown(object? modifierKey) => default!;

}
