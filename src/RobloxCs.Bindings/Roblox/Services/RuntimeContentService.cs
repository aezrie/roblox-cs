using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class RuntimeContentService : Instance
{
    // Events
    public event Action<string> RuntimeContentFail = null!;
    public event Action<string, string> RuntimeContentLRCleanup = null!;
    public event Action<string, string, string> RuntimeContentQuery = null!;
    public event Action<string, string, string> RuntimeContentShare = null!;
}
