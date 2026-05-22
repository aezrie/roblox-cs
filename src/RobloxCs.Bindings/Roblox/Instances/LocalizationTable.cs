using System;

namespace Roblox.Instances;

public class LocalizationTable : Instance
{
    // Properties
    public string? SourceLocaleId { get; set; } = null!;

    // Methods
    public object[] GetEntries() => default!;
    public Instance GetTranslator(string? localeId) => null!;
    public object RemoveEntry(string? key, string? source, string? context) => null!;
    public object RemoveEntryValue(string? key, string? source, string? context, string? localeId) => null!;
    public object RemoveTargetLocale(string? localeId) => null!;
    public object SetEntries(object? entries) => null!;
    public object SetEntryContext(string? key, string? source, string? context, string? newContext) => null!;
    public object SetEntryExample(string? key, string? source, string? context, string? example) => null!;
    public object SetEntryKey(string? key, string? source, string? context, string? newKey) => null!;
    public object SetEntrySource(string? key, string? source, string? context, string? newSource) => null!;
    public object SetEntryValue(string? key, string? source, string? context, string? localeId, string? text) => null!;

}
