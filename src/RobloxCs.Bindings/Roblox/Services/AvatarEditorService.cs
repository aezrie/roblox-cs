using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class AvatarEditorService : Instance
{
    // Methods
    public object GetAccessoryType(object? avatarAssetType) => null!;
    public object PromptAllowInventoryReadAccess() => null!;
    public object PromptCreateOutfit(object? outfit, object? rigType) => null!;
    public object PromptDeleteOutfit(long outfitId) => null!;
    public object PromptRenameOutfit(long outfitId) => null!;
    public object PromptSaveAvatar(object? humanoidDescription, object? rigType) => null!;
    public object PromptSetFavorite(long itemId, object? itemType, bool shouldFavorite) => null!;
    public object PromptUpdateOutfit(long outfitId, object? updatedOutfit, object? rigType) => null!;
    public object CheckApplyDefaultClothingAsync(object? humanoidDescription) => null!;
    public object ConformToAvatarRulesAsync(object? humanoidDescription) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetAvatarRulesAsync() => default!;
    public object[] GetBatchItemDetailsAsync(object[]? itemIds, object? itemType) => default!;
    public object GetBundlesByAssetIdAsync(long assetId, long limit = default) => null!;
    public bool GetFavoriteAsync(long itemId, object? itemType) => default!;
    public object[] GetHeadShapesAsync() => default!;
    public object GetInventoryAsync(object[]? assetTypes) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetItemDetailsAsync(long itemId, object? itemType) => default!;
    public System.Collections.Generic.Dictionary<string, object> GetOutfitDetailsAsync(long outfitId) => default!;
    public object GetOutfitsAsync(object? outfitSource = null, object? outfitType = null) => null!;
    public object[] GetRecommendedAssetsAsync(object? assetType, long contextAssetId = 0) => default!;
    public object[] GetRecommendedBundlesAsync(long bundleId) => default!;
    public object SearchCatalogAsync(object? searchParameters) => null!;

    // Events
    public event Action<object> PromptAllowInventoryReadAccessCompleted = null!;
    public event Action<object, object> PromptCreateOutfitCompleted = null!;
    public event Action<object> PromptDeleteOutfitCompleted = null!;
    public event Action<object> PromptRenameOutfitCompleted = null!;
    public event Action<object, object> PromptSaveAvatarCompleted = null!;
    public event Action<object> PromptSetFavoriteCompleted = null!;
    public event Action<object> PromptUpdateOutfitCompleted = null!;
}
