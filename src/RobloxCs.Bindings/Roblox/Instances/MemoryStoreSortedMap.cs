using System;

namespace Roblox.Instances;

public class MemoryStoreSortedMap : Instance
{
    // Methods
    public object[] GetAsync(string? key) => default!;
    public object[] GetRangeAsync(object? direction, int count, object? exclusiveLowerBound, object? exclusiveUpperBound) => default!;
    public int GetSizeAsync() => default!;
    public object RemoveAsync(string? key) => null!;
    public bool SetAsync(string? key, object? value, long expiration, object? sortKey) => default!;
    public object[] UpdateAsync(string? key, Delegate? transformFunction, long expiration) => default!;

}
