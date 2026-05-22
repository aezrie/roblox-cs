using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class TeleportService : Instance
{
    // Methods
    public Instance GetArrivingTeleportGui() => null!;
    public object GetLocalPlayerTeleportData() => null!;
    public object GetTeleportSetting(string? setting) => null!;
    public object SetTeleportGui(Instance? gui) => null!;
    public object SetTeleportSetting(string? setting, object? value) => null!;
    public object Teleport(long placeId, Instance? player = null, object? teleportData = null, Instance? customLoadingScreen = null) => null!;
    public object TeleportToPlaceInstance(long placeId, string? instanceId, Instance? player = null, string? spawnName = null, object? teleportData = null, Instance? customLoadingScreen = null) => null!;
    public object TeleportToPrivateServer(long placeId, string? reservedServerAccessCode, object? players, string? spawnName = null, object? teleportData = null, Instance? customLoadingScreen = null) => null!;
    public object TeleportToSpawnByName(long placeId, string? spawnName, Instance? player = null, object? teleportData = null, Instance? customLoadingScreen = null) => null!;
    public object[] GetPlayerPlaceInstanceAsync(long userId) => default!;
    public object PromptExperienceDetailsAsync(object? player, long universeId) => null!;
    public object[] ReserveServerAsync(long placeId) => default!;
    public Instance TeleportAsync(long placeId, object? players, Instance? teleportOptions = null) => null!;
    public string TeleportPartyAsync(long placeId, object? players, object? teleportData, Instance? customLoadingScreen = null) => default!;

    // Events
    public event Action<Instance, object> LocalPlayerArrivedFromTeleport = null!;
    public event Action<Instance, object, string, long, Instance> TeleportInitFailed = null!;
}
