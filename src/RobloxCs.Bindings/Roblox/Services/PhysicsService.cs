using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class PhysicsService : Instance
{
    // Methods
    public object CollisionGroupSetCollidable(string? name1, string? name2, bool collidable) => null!;
    public bool CollisionGroupsAreCollidable(string? name1, string? name2) => default!;
    public int GetMaxCollisionGroups() => default!;
    public object[] GetRegisteredCollisionGroups() => default!;
    public bool IsCollisionGroupRegistered(string? name) => default!;
    public object RegisterCollisionGroup(string? name) => null!;
    public object RenameCollisionGroup(string? from, string? to) => null!;
    public object UnregisterCollisionGroup(string? name) => null!;

}
