using System;

namespace Roblox.Instances;

public class SyncScriptBuilder : ScriptBuilder
{
    // Properties
    public object? CompileTarget { get; set; } = null!;
    public bool CoverageInfo { get; set; }
    public bool DebugInfo { get; set; }
    public bool PackAsSource { get; set; }

}
