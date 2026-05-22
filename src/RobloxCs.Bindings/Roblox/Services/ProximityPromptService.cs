using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class ProximityPromptService : Instance
{
    // Properties
    public bool Enabled { get; set; }
    public int MaxIndicatorsVisible { get; set; }
    public int MaxPromptsVisible { get; set; }

    // Events
    public event Action<object> IndicatorHidden = null!;
    public event Action<object> IndicatorShown = null!;
    public event Action<object, object> PromptButtonHoldBegan = null!;
    public event Action<object, object> PromptButtonHoldEnded = null!;
    public event Action<object> PromptHidden = null!;
    public event Action<object, object> PromptShown = null!;
    public event Action<object, object> PromptTriggerEnded = null!;
    public event Action<object, object> PromptTriggered = null!;
}
