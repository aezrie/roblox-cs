using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class MLService : Instance
{
    // Methods
    public bool IsPostProcessReady() => default!;
    public object SetPostProcessEnabled(bool enabled) => null!;
    public object CreateSessionAsync(string? assetId) => null!;
    public object LoadPostProcessModelAsync(long assetId) => null!;

}
