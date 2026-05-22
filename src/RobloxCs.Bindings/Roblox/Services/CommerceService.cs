using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class CommerceService : Instance
{
    // Methods
    public object PromptCommerceProductPurchase(object? user, string? commerceProductId) => null!;
    public object PromptRealWorldCommerceBrowser(object? player, string? url) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetCommerceProductInfoAsync(string? commerceProductId) => default!;
    public bool UserEligibleForRealWorldCommerceAsync() => default!;

    // Events
    public event Action<object, string> PromptCommerceProductPurchaseFinished = null!;
}
