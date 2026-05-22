using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class AvatarCreationService : Instance
{
    // Methods
    public System.Collections.Generic.Dictionary<string, object> GetValidationRules() => default!;
    public string AutoSetupAvatarAsync(object? player, System.Collections.Generic.Dictionary<string, object> autoSetupParams, object? progressCallback) => default!;
    public string GenerateAvatar2DPreviewAsync(System.Collections.Generic.Dictionary<string, object> avatarGeneration2dPreviewParams) => default!;
    public string GenerateAvatarAsync(System.Collections.Generic.Dictionary<string, object> avatarGenerationParams) => default!;
    public object[] GetBatchTokenDetailsAsync(object[]? tokenIds) => default!;
    public object LoadAvatar2DPreviewAsync(string? previewId) => null!;
    public object LoadGeneratedAvatarAsync(string? generationId) => null!;
    public object PrepareAvatarForPreviewAsync(object? humanoidModel) => null!;
    public object[] PromptCreateAvatarAssetAsync(string? tokenId, object? player, Instance? assetInstance, object? assetType) => default!;
    public object[] PromptCreateAvatarAsync(string? tokenId, object? player, object? humanoidDescription) => default!;
    public string PromptSelectAvatarGenerationImageAsync(object? player) => default!;
    public object[] RequestAvatarGenerationSessionAsync(object? player, Delegate? callback) => default!;
    public object[] ValidateUGCAccessoryAsync(object? player, Instance? accessory, object? accessoryType) => default!;
    public object[] ValidateUGCBodyPartAsync(object? player, Instance? instance, object? bodyPart) => default!;
    public object[] ValidateUGCFullBodyAsync(object? player, object? humanoidDescription) => default!;

    // Events
    public event Action<long, object> AvatarAssetModerationCompleted = null!;
    public event Action<long, object> AvatarModerationCompleted = null!;
}
