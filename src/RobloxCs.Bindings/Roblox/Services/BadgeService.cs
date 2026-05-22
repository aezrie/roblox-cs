using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class BadgeService : Instance
{
    // Methods
    public bool AwardBadgeAsync(long userId, long badgeId) => default!;
    public object[] CheckUserBadgesAsync(long userId, object[]? badgeIds) => default!;
    public System.Collections.Generic.Dictionary<string, object> GetBadgeInfoAsync(long badgeId) => default!;
    public bool UserHasBadgeAsync(long userId, long badgeId) => default!;

}
