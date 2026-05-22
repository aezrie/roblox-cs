using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class ConfigService : Instance
{
    // Methods
    public object ClearTestingValue(string? key) => null!;
    public object SetTestingValue(string? key, object? value) => null!;
    public object GetConfigAsync() => null!;
    public object GetConfigForPlayerAsync(object? player) => null!;

}
