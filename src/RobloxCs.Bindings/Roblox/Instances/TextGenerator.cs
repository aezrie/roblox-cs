using System;

namespace Roblox.Instances;

public class TextGenerator : Instance
{
    // Properties
    public int Seed { get; set; }
    public string? SystemPrompt { get; set; } = null!;
    public float Temperature { get; set; }
    public float TopP { get; set; }

    // Methods
    public System.Collections.Generic.Dictionary<string, object> GenerateTextAsync(System.Collections.Generic.Dictionary<string, object> request) => default!;

}
