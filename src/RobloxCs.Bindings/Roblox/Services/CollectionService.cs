using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class CollectionService : Instance
{
    // Methods
    public object AddTag(Instance? instance, string? tag) => null!;
    public object[] GetAllTags() => default!;
    public object GetInstanceAddedSignal(string? tag) => null!;
    public object GetInstanceRemovedSignal(string? tag) => null!;
    public object GetTagged(string? tag) => null!;
    public object[] GetTags(Instance? instance) => default!;
    public bool HasTag(Instance? instance, string? tag) => default!;
    public object RemoveTag(Instance? instance, string? tag) => null!;

    // Events
    public event Action<string> TagAdded = null!;
    public event Action<string> TagRemoved = null!;
}
