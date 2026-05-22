using System;

namespace Roblox.Instances;

public class TextChatCommand : Instance
{
    // Properties
    public bool AutocompleteVisible { get; set; }
    public bool Enabled { get; set; }
    public string? PrimaryAlias { get; set; } = null!;
    public string? SecondaryAlias { get; set; } = null!;

    // Events
    public event Action<object, string> Triggered = null!;
}
