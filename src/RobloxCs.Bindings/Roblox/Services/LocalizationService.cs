using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class LocalizationService : Instance
{
    // Properties
    public string? RobloxLocaleId { get; } = null!;
    public string? SystemLocaleId { get; } = null!;

    // Methods
    public object GetCorescriptLocalizations() => null!;
    public object[] GetTableEntries(Instance? instance = null) => default!;
    public Instance GetTranslatorForPlayer(Instance? player) => null!;
    public string GetCountryRegionForPlayerAsync(Instance? player) => default!;
    public Instance GetTranslatorForLocaleAsync(string? locale) => null!;
    public Instance GetTranslatorForPlayerAsync(Instance? player) => null!;

}
