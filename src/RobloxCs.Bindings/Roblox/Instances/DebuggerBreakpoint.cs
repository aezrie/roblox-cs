using System;

namespace Roblox.Instances;

public class DebuggerBreakpoint : Instance
{
    // Properties
    public string? Condition { get; set; } = null!;
    public bool ContinueExecution { get; set; }
    public bool IsEnabled { get; set; }
    public int Line { get; }
    public string? LogExpression { get; set; } = null!;
    public bool isContextDependentBreakpoint { get; set; }

}
