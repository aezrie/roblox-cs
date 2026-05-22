using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class VirtualInput : Object
{
    // Methods
    public object SendKey(bool isPressed, object? keyCode, bool isRepeatedKey = false) => null!;
    public object SendMouseButton(Vector2 position, object? button, bool isDown, int repeatCount = 0) => null!;
    public object SendMouseDelta(Vector2 positionDelta) => null!;
    public object SendMousePosition(Vector2 position) => null!;
    public object SendPointerAction(Vector2 position, System.Collections.Generic.Dictionary<string, object> pointerAction) => null!;
    public object SendTextInput(string? text) => null!;

}
