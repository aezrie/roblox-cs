using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class AssetService : Instance
{
    // Methods
    public object CreateEditableImage(object? editableImageOptions) => null!;
    public object CreateEditableMesh(object? editableMeshOptions) => null!;
    public object ComposeDecalAsync(object? decal, object[]? layers) => null!;
    public object[] CreateAssetAsync(object? @object, object? assetType, System.Collections.Generic.Dictionary<string, object> requestParameters = null) => default!;
    public object[] CreateAssetVersionAsync(object? @object, object? assetType, long assetId, System.Collections.Generic.Dictionary<string, object> requestParameters = null) => default!;
    public object[] CreateDataModelContentAsync(string? content, object? options) => default!;
    public object CreateEditableImageAsync(string? content, object? editableImageOptions) => null!;
    public object CreateEditableMeshAsync(string? content, object? editableMeshOptions) => null!;
    public object CreateMeshPartAsync(string? meshContent, System.Collections.Generic.Dictionary<string, object> options = null) => null!;
    public long CreatePlaceAsync(string? placeName, long templatePlaceID, string? description = null) => default!;
    public long CreatePlaceInPlayerInventoryAsync(Instance? player, string? placeName, long templatePlaceID, string? description = null) => default!;
    public object CreateSurfaceAppearanceAsync(System.Collections.Generic.Dictionary<string, object> content) => null!;
    public object[] GetAssetIdsForPackageAsync(long packageAssetId) => default!;
    public object[] GetAudioMetadataAsync(object[]? idList) => default!;
    public System.Collections.Generic.Dictionary<string, object> GetBundleDetailsAsync(long bundleId) => default!;
    public Instance GetGamePlacesAsync() => null!;
    public Instance LoadAssetAsync(long assetId) => null!;
    public object[] PromptCreateAssetAsync(object? player, Instance? instance, object? assetType) => default!;
    public object[] PromptImportAnimationClipFromVideoAsync(object? player, Delegate? progressCallback) => default!;
    public object SavePlaceAsync(object? requestParameters) => null!;
    public object SearchAudioAsync(object? searchParameters) => null!;

}
