using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class ContentProvider : Instance
{
    // Properties
    public string? BaseUrl { get; } = null!;
    public int RequestQueueSize { get; }

    // Methods
    public object GetAssetFetchStatus(object? contentId) => null!;
    public object GetAssetFetchStatusChangedSignal(object? contentId) => null!;
    public object[] ListEncryptedAssets() => default!;
    public object RegisterDefaultEncryptionKey(string? encryptionKey) => null!;
    public object RegisterDefaultSessionKey(string? sessionKey) => null!;
    public object RegisterEncryptedAsset(object? assetId, string? encryptionKey) => null!;
    public object RegisterSessionEncryptedAsset(object? contentId, string? sessionKey) => null!;
    public object UnregisterDefaultEncryptionKey() => null!;
    public object UnregisterEncryptedAsset(object? assetId) => null!;
    public object PreloadAsync(object[]? contentIdList, Delegate? callbackFunction = null) => null!;

    // Events
    public event Action<object> AssetFetchFailed = null!;
}
