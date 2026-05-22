using System;

namespace Roblox.Instances;

public class DataModel : ServiceProvider
{
    // Properties
    public long CreatorId { get; }
    public object? CreatorType { get; } = null!;
    public long GameId { get; }
    public object? Genre { get; } = null!;
    public string? JobId { get; } = null!;
    public object? MatchmakingType { get; } = null!;
    public long PlaceId { get; }
    public int PlaceVersion { get; }
    public string? PrivateServerId { get; } = null!;
    public long PrivateServerOwnerId { get; }
    public object? RunService { get; } = null!;
    public object? Workspace { get; } = null!;

    // Methods
    public object BindToClose(Delegate? function) => null!;
    public bool IsLoaded() => default!;

    // Events
    public event Action<bool> GraphicsQualityChangeRequest = null!;
    public event Action Loaded = null!;
    public event Action<System.Collections.Generic.Dictionary<string, object>> ServerLifecycleChanged = null!;
}
