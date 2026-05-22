using System;

namespace Roblox.Instances;

public class TextFilterTranslatedResult : Instance
{
    // Properties
    public string? SourceLanguage { get; } = null!;
    public object? SourceText { get; } = null!;

    // Methods
    public object GetTranslationForLocale(string? locale) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetTranslations() => default!;

}
