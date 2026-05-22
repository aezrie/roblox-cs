using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class GroupService : Instance
{
    // Methods
    public object GetAlliesAsync(long groupId) => null!;
    public object GetEnemiesAsync(long groupId) => null!;
    public object GetGroupInfoAsync(long groupId) => null!;
    public object[] GetGroupsAsync(long userId) => default!;
    public object PromptJoinAsync(long groupId) => null!;

}
