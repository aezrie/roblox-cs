using System;

namespace Roblox.Instances;

public class GlobalDataStore : Instance
{
    // Methods
    public object[] GetAsync(string? key, object? options = null) => default!;
    public object IncrementAsync(string? key, int delta = 1, object[]? userIds = null, object? options = null) => null!;
    public object[] RemoveAsync(string? key) => default!;
    public object SetAsync(string? key, object? value, object[]? userIds = null, object? options = null) => null!;
    public object[] UpdateAsync(string? key, Delegate? transformFunction) => default!;

}
