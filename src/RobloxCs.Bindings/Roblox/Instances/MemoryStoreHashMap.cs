using System;

namespace Roblox.Instances;

public class MemoryStoreHashMap : Instance
{
    // Methods
    public object GetAsync(string? key) => null!;
    public object ListItemsAsync(int count) => null!;
    public object RemoveAsync(string? key) => null!;
    public bool SetAsync(string? key, object? value, long expiration) => default!;
    public object UpdateAsync(string? key, Delegate? transformFunction, long expiration) => null!;

}
