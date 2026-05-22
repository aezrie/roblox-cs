using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Dialog : Instance
{
    // Properties
    public object? BehaviorType { get; set; } = null!;
    public float ConversationDistance { get; set; }
    public bool GoodbyeChoiceActive { get; set; }
    public string? GoodbyeDialog { get; set; } = null!;
    public bool InUse { get; set; }
    public string? InitialPrompt { get; set; } = null!;
    public object? Purpose { get; set; } = null!;
    public object? Tone { get; set; } = null!;
    public float TriggerDistance { get; set; }
    public Vector3 TriggerOffset { get; set; }

    // Methods
    public object GetCurrentPlayers() => null!;

    // Events
    public event Action<Instance, Instance> DialogChoiceSelected = null!;
}
