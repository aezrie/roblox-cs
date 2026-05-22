using System;

namespace Roblox.Instances;

public class DataStore : GlobalDataStore
{
    // Methods
    public object[] GetVersionAsync(string? key, string? version) => default!;
    public object[] GetVersionAtTimeAsync(string? key, long timestamp) => default!;
    public object ListKeysAsync(string? prefix = null, int pageSize = 0, string? cursor = null, bool excludeDeleted = false) => null!;
    public object ListVersionsAsync(string? key, object? sortDirection = null, long minDate = 0, long maxDate = 0, int pageSize = 0) => null!;

}
