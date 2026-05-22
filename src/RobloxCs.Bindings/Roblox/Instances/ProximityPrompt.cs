using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ProximityPrompt : Instance
{
    // Properties
    public string? ActionText { get; set; } = null!;
    public bool AutoLocalize { get; set; }
    public bool ClickablePrompt { get; set; }
    public bool Enabled { get; set; }
    public object? Exclusivity { get; set; } = null!;
    public object? GamepadKeyCode { get; set; } = null!;
    public float HoldDuration { get; set; }
    public object? KeyboardKeyCode { get; set; } = null!;
    public float MaxActivationDistance { get; set; }
    public float MaxIndicatorDistance { get; set; }
    public string? ObjectText { get; set; } = null!;
    public bool RequiresLineOfSight { get; set; }
    public object? RootLocalizationTable { get; set; } = null!;
    public object? Style { get; set; } = null!;
    public Vector2 UIOffset { get; set; }

    // Methods
    public object InputHoldBegin() => null!;
    public object InputHoldEnd() => null!;

    // Events
    public event Action IndicatorHidden = null!;
    public event Action IndicatorShown = null!;
    public event Action<object> PromptButtonHoldBegan = null!;
    public event Action<object> PromptButtonHoldEnded = null!;
    public event Action PromptHidden = null!;
    public event Action<object> PromptShown = null!;
    public event Action<object> TriggerEnded = null!;
    public event Action<object> Triggered = null!;
}
