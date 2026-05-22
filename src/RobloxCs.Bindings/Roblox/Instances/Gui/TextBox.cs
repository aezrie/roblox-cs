using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class TextBox : GuiObject
{
    // Properties
    public bool ClearTextOnFocus { get; set; }
    public string? ContentText { get; } = null!;
    public int CursorPosition { get; set; }
    public object? FontFace { get; set; } = null!;
    public float LineHeight { get; set; }
    public int MaxVisibleGraphemes { get; set; }
    public bool MultiLine { get; set; }
    public string? OpenTypeFeatures { get; set; } = null!;
    public string? OpenTypeFeaturesError { get; } = null!;
    public Color3 PlaceholderColor3 { get; set; }
    public string? PlaceholderText { get; set; } = null!;
    public bool RichText { get; set; }
    public int SelectionStart { get; set; }
    public bool ShowNativeInput { get; set; }
    public string? Text { get; set; } = null!;
    public Vector2 TextBounds { get; }
    public Color3 TextColor3 { get; set; }
    public object? TextDirection { get; set; } = null!;
    public bool TextEditable { get; set; }
    public bool TextFits { get; }
    public bool TextScaled { get; set; }
    public float TextSize { get; set; }
    public Color3 TextStrokeColor3 { get; set; }
    public float TextStrokeTransparency { get; set; }
    public float TextTransparency { get; set; }
    public object? TextTruncate { get; set; } = null!;
    public bool TextWrapped { get; set; }
    public object? TextXAlignment { get; set; } = null!;
    public object? TextYAlignment { get; set; } = null!;

    // Methods
    public object CaptureFocus() => null!;
    public bool IsFocused() => default!;
    public object ReleaseFocus(bool submitted = false) => null!;

    // Events
    public event Action<bool, object> FocusLost = null!;
    public event Action Focused = null!;
    public event Action ReturnPressedFromOnScreenKeyboard = null!;
}
