using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class LiveSyncService : Instance
{
    // Properties
    public bool HasSyncedInstances { get; }

    // Methods
    public object[] GetSyncState(Instance? instance) => default!;

    // Events
    public event Action<Instance> SyncStatusChanged = null!;
}
