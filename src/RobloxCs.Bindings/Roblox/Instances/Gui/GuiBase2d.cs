using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public abstract class GuiBase2d : GuiBase
{
    // Properties
    public Vector2 AbsolutePosition { get; }
    public float AbsoluteRotation { get; }
    public Vector2 AbsoluteSize { get; }
    public bool AutoLocalize { get; set; }
    public object? RootLocalizationTable { get; set; } = null!;
    public object? SelectionBehaviorDown { get; set; } = null!;
    public object? SelectionBehaviorLeft { get; set; } = null!;
    public object? SelectionBehaviorRight { get; set; } = null!;
    public object? SelectionBehaviorUp { get; set; } = null!;
    public bool SelectionGroup { get; set; }

    // Events
    public event Action<bool, object, object> SelectionChanged = null!;
}
