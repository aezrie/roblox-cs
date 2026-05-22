using System;

namespace Roblox.Instances;

public class Translator : Instance
{
    // Properties
    public string? LocaleId { get; } = null!;

    // Methods
    public string FormatByKey(string? key, object? args) => default!;
    public string Translate(Instance? context, string? text) => default!;

}
