using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class MarketplaceService : Instance
{
    // Methods
    public object BindReceiptHandler(object? transactionType, Delegate? handler, object? filter) => null!;
    public object OpenShop(object? player) => null!;
    public object PromptBulkPurchase(object? player, object[]? lineItems, System.Collections.Generic.Dictionary<string, object> options) => null!;
    public object PromptBundlePurchase(Instance? player, long bundleId) => null!;
    public object PromptCancelSubscription(object? user, string? subscriptionId) => null!;
    public object PromptGamePassPurchase(Instance? player, long gamePassId) => null!;
    public object PromptProductPurchase(Instance? player, long productId, bool equipIfPurchased = true, object? currencyType = null) => null!;
    public object PromptPurchase(Instance? player, long assetId, bool equipIfPurchased = true, object? currencyType = null) => null!;
    public object PromptRobloxSubscriptionPurchase(object? user) => null!;
    public object PromptSubscriptionPurchase(object? user, string? subscriptionId) => null!;
    public Instance GetDeveloperProductsAsync() => null!;
    public System.Collections.Generic.Dictionary<string, object> GetProductInfoAsync(long assetId, object? infoType = null) => default!;
    public System.Collections.Generic.Dictionary<string, object> GetRobloxSubscriptionDetailsAsync(object? user) => default!;
    public System.Collections.Generic.Dictionary<string, object> GetSubscriptionProductInfoAsync(string? subscriptionId) => default!;
    public System.Collections.Generic.Dictionary<string, object> GetUserSubscriptionDetailsAsync(object? user, string? subscriptionId) => default!;
    public object[] GetUserSubscriptionPaymentHistoryAsync(object? user, string? subscriptionId) => default!;
    public System.Collections.Generic.Dictionary<string, object> GetUserSubscriptionStatusAsync(object? user, string? subscriptionId) => default!;
    public object[] GetUsersPriceLevelsAsync(object[]? userIds) => default!;
    public bool PlayerOwnsAssetAsync(Instance? player, long assetId) => default!;
    public bool PlayerOwnsBundleAsync(object? player, long bundleId) => default!;
    public string PromptRobuxTransferAsync(object? sender, long receiverUserId, long amount) => default!;
    public object[] RankProductsAsync(object[]? productIdentifiers) => default!;
    public object[] RecommendTopProductsAsync(object[]? infoTypes) => default!;
    public bool UserOwnsGamePassAsync(long userId, long gamePassId) => default!;

    // Callbacks
    public Func<System.Collections.Generic.Dictionary<string, object>, object>? ProcessReceipt { get; set; }

    // Events
    public event Action<Instance, object, System.Collections.Generic.Dictionary<string, object>> PromptBulkPurchaseFinished = null!;
    public event Action<Instance, long, bool> PromptBundlePurchaseFinished = null!;
    public event Action<Instance, long, bool> PromptGamePassPurchaseFinished = null!;
    public event Action PromptPremiumPurchaseFinished = null!;
    public event Action<long, long, bool> PromptProductPurchaseFinished = null!;
    public event Action<Instance, long, bool> PromptPurchaseFinished = null!;
    public event Action<object, bool> PromptRobloxSubscriptionPurchaseFinished = null!;
    public event Action<object, string, bool> PromptSubscriptionPurchaseFinished = null!;
}
