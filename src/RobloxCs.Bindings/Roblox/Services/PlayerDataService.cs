using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class PlayerDataService : Instance
{
    // Properties
    public object? LoadFailureBehavior { get; set; } = null!;

    // Methods
    public object GetRecordConfig(string? recordName = null) => null!;

}
