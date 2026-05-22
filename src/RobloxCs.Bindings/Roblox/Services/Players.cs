using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class Players : Instance
{
    // Properties
    public bool BubbleChat { get; }
    public bool CharacterAutoLoads { get; set; }
    public bool ClassicChat { get; }
    public object? LocalPlayer { get; } = null!;
    public int MaxPlayers { get; }
    public int PreferredPlayers { get; }
    public float RespawnTime { get; set; }

    // Methods
    public object GetPlayerByUserId(long userId) => null!;
    public object GetPlayerFromCharacter(object? character) => null!;
    public object GetPlayers() => null!;
    public object BanAsync(System.Collections.Generic.Dictionary<string, object> config) => null!;
    public object CreateHumanoidModelFromDescriptionAsync(object? description, object? rigType, object? assetTypeVerification = null) => null!;
    public object CreateHumanoidModelFromUserIdAsync(long userId) => null!;
    public object GetBanHistoryAsync(long userId) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetCharacterAppearanceInfoAsync(long userId) => default!;
    public object GetFriendsAsync(long userId) => null!;
    public object GetHumanoidDescriptionFromOutfitIdAsync(long outfitId) => null!;
    public object GetHumanoidDescriptionFromUserIdAsync(long userId) => null!;
    public string GetNameFromUserIdAsync(long userId) => default!;
    public long GetUserIdFromNameAsync(string? userName) => default!;
    public object[] GetUserThumbnailAsync(long userId, object? thumbnailType, object? thumbnailSize) => default!;
    public object UnbanAsync(System.Collections.Generic.Dictionary<string, object> config) => null!;

    // Events
    public event Action<object> PlayerAdded = null!;
    public event Action<object> PlayerMembershipChanged = null!;
    public event Action<object, object> PlayerRemoving = null!;
    public event Action<object, string> UserSubscriptionStatusChanged = null!;
}
