using System;

namespace Roblox.Instances;

public class MemoryStoreQueue : Instance
{
    // Methods
    public object AddAsync(object? value, long expiration, double priority = 0) => null!;
    public int GetSizeAsync(bool excludeInvisible = false) => default!;
    public object[] ReadAsync(int count, bool allOrNothing = false, double waitTimeout = default) => default!;
    public object RemoveAsync(string? id) => null!;

}
