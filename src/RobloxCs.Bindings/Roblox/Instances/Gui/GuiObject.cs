using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public abstract class GuiObject : GuiBase2d
{
    // Properties
    public bool Active { get; set; }
    public Vector2 AnchorPoint { get; set; }
    public object? AutomaticSize { get; set; } = null!;
    public Color3 BackgroundColor3 { get; set; }
    public float BackgroundTransparency { get; set; }
    public Color3 BorderColor3 { get; set; }
    public object? BorderMode { get; set; } = null!;
    public int BorderSizePixel { get; set; }
    public bool ClipsDescendants { get; set; }
    public object? GuiState { get; } = null!;
    public object? InputSink { get; set; } = null!;
    public bool Interactable { get; set; }
    public int LayoutOrder { get; set; }
    public object? NextSelectionDown { get; set; } = null!;
    public object? NextSelectionLeft { get; set; } = null!;
    public object? NextSelectionRight { get; set; } = null!;
    public object? NextSelectionUp { get; set; } = null!;
    public UDim2 Position { get; set; }
    public float Rotation { get; set; }
    public bool Selectable { get; set; }
    public object? SelectionImageObject { get; set; } = null!;
    public int SelectionOrder { get; set; }
    public UDim2 Size { get; set; }
    public object? SizeConstraint { get; set; } = null!;
    public bool Visible { get; set; }
    public int ZIndex { get; set; }

    // Methods
    public bool TweenPosition(UDim2 endPosition, object? easingDirection = null, object? easingStyle = null, float time = 1, bool @override = false, Delegate? callback = null) => default!;
    public bool TweenSize(UDim2 endSize, object? easingDirection = null, object? easingStyle = null, float time = 1, bool @override = false, Delegate? callback = null) => default!;
    public bool TweenSizeAndPosition(UDim2 endSize, UDim2 endPosition, object? easingDirection = null, object? easingStyle = null, float time = 1, bool @override = false, Delegate? callback = null) => default!;

    // Events
    public event Action<object> InputBegan = null!;
    public event Action<object> InputChanged = null!;
    public event Action<object> InputEnded = null!;
    public event Action<int, int> MouseEnter = null!;
    public event Action<int, int> MouseLeave = null!;
    public event Action<int, int> MouseMoved = null!;
    public event Action<int, int> MouseWheelBackward = null!;
    public event Action<int, int> MouseWheelForward = null!;
    public event Action SelectionGained = null!;
    public event Action SelectionLost = null!;
    public event Action<object[], object> TouchLongPress = null!;
    public event Action<object[], Vector2, Vector2, object> TouchPan = null!;
    public event Action<object[], float, float, object> TouchPinch = null!;
    public event Action<object[], float, float, object> TouchRotate = null!;
    public event Action<object, int> TouchSwipe = null!;
    public event Action<object[]> TouchTap = null!;
}
