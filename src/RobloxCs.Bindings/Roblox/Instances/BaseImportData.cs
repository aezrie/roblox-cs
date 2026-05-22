using System;

namespace Roblox.Instances;

public class BaseImportData : Instance
{
    // Properties
    public string? Id { get; } = null!;
    public string? ImportName { get; set; } = null!;
    public bool ShouldImport { get; set; }

    // Events
    public event Action<System.Collections.Generic.Dictionary<string, object>> StatusRemoved = null!;
    public event Action<System.Collections.Generic.Dictionary<string, object>> StatusReported = null!;
}
