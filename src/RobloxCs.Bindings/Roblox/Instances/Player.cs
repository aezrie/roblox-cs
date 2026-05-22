using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Player : Instance
{
    // Properties
    public int AccountAge { get; }
    public bool AutoJumpEnabled { get; set; }
    public float CameraMaxZoomDistance { get; set; }
    public float CameraMinZoomDistance { get; set; }
    public object? CameraMode { get; set; } = null!;
    public bool CanLoadCharacterAppearance { get; set; }
    public object? Character { get; set; } = null!;
    public long CharacterAppearanceId { get; set; }
    public object? DevCameraOcclusionMode { get; set; } = null!;
    public object? DevComputerCameraMode { get; set; } = null!;
    public object? DevComputerMovementMode { get; set; } = null!;
    public bool DevEnableMouseLock { get; set; }
    public object? DevTouchCameraMode { get; set; } = null!;
    public object? DevTouchMovementMode { get; set; } = null!;
    public string? DisplayName { get; set; } = null!;
    public long FollowUserId { get; }
    public bool HasVerifiedBadge { get; set; }
    public float HealthDisplayDistance { get; set; }
    public object? MembershipType { get; } = null!;
    public float NameDisplayDistance { get; set; }
    public bool Neutral { get; set; }
    public Instance? ReplicationFocus { get; set; } = null!;
    public object? RespawnLocation { get; set; } = null!;
    public object? Team { get; set; } = null!;
    public BrickColor TeamColor { get; set; }
    public long UserId { get; set; }

    // Methods
    public object AddReplicationFocus(object? part) => null!;
    public object ClearCachedAvatarAppearance() => null!;
    public object ClearCharacterAppearance() => null!;
    public float DistanceFromCharacter(Vector3 point) => default!;
    public object GetData() => null!;
    public System.Collections.Generic.Dictionary<string, object> GetJoinData() => default!;
    public object GetMouse() => null!;
    public float GetNetworkPing() => default!;
    public bool HasAppearanceLoaded() => default!;
    public bool IsVerified() => default!;
    public object Kick(string? message = null) => null!;
    public object Move(Vector3 walkDirection, bool relativeToCamera = false) => null!;
    public object RemoveReplicationFocus(object? part) => null!;
    public object[] GetFriendsOnlineAsync(int maxFriends = default) => default!;
    public object[] GetFriendsWhoPlayedAsync() => default!;
    public int GetRankInGroupAsync(long groupId) => default!;
    public string GetRoleInGroupAsync(long groupId) => default!;
    public bool IsFriendsWithAsync(long userId) => default!;
    public bool IsInGroupAsync(long groupId) => default!;
    public object LoadCharacterAsync() => null!;
    public object LoadCharacterWithHumanoidDescriptionAsync(object? humanoidDescription, object? assetTypeVerification = null) => null!;
    public object RequestStreamAroundAsync(Vector3 position, double timeOut = 0) => null!;

    // Events
    public event Action<object> CharacterAdded = null!;
    public event Action<object> CharacterAppearanceLoaded = null!;
    public event Action<object> CharacterRemoving = null!;
    public event Action<string, object> Chatted = null!;
    public event Action<double> Idled = null!;
    public event Action<object, long, string> OnTeleport = null!;
}
