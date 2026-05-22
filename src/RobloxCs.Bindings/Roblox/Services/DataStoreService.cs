using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class DataStoreService : Instance
{
    // Methods
    public object GetDataStore(string? name, string? scope = null, Instance? options = null) => null!;
    public object GetGlobalDataStore() => null!;
    public object GetOrderedDataStore(string? name, string? scope = null) => null!;
    public int GetRequestBudgetForRequestType(object? requestType) => default!;
    public object SetRateLimitForRequestType(object? requestType, int baseLimit, int perPlayerLimit) => null!;
    public object ListDataStoresAsync(string? prefix = null, int pageSize = 0, string? cursor = null) => null!;

}
