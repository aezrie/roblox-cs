using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class RecommendationService : Instance
{
    // Methods
    public object LogActionEvent(object? actionType, string? itemId, string? tracingId, System.Collections.Generic.Dictionary<string, object> actionEventDetails = null) => null!;
    public object LogImpressionEvent(object? impressionType, string? itemId, string? tracingId, System.Collections.Generic.Dictionary<string, object> impressionEventDetails = null) => null!;
    public object LogPreferenceEvent(object? preferenceType, object? targetType, string? targetId, string? tracingId = null, string? itemId = null) => null!;
    public object GenerateItemListAsync(System.Collections.Generic.Dictionary<string, object> generateRecommendationItemListRequest) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetRecommendationItemAsync(string? itemId) => default!;
    public System.Collections.Generic.Dictionary<string, object> RegisterItemAsync(object? player, System.Collections.Generic.Dictionary<string, object> registerRecommendationItemsRequest) => default!;
    public object RemoveItemAsync(string? itemId) => null!;
    public object UpdateItemAsync(System.Collections.Generic.Dictionary<string, object> updateRecommendationItemRequest) => null!;

}
