using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class InsertService : Instance
{
    // Methods
    public object CreateMeshPartAsync(object? meshId, object? collisionFidelity, object? renderFidelity) => null!;
    public object[] GetFreeDecalsAsync(string? searchText, int pageNum) => default!;
    public object[] GetFreeModelsAsync(string? searchText, int pageNum) => default!;
    public long GetLatestAssetVersionAsync(long assetId) => default!;
    public Instance LoadAsset(long assetId) => null!;
    public Instance LoadAssetVersion(long assetVersionId) => null!;

}
