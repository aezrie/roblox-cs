using System;

namespace Roblox.Instances;

public class ScriptDebugger : Instance
{
    // Properties
    public int CurrentLine { get; }
    public bool IsDebugging { get; }
    public bool IsPaused { get; }
    public Instance? Script { get; } = null!;

    // Methods
    public Instance AddWatch(string? expression) => null!;
    public object GetBreakpoints() => null!;
    public object GetGlobals(int stackFrame = 0) => null!;
    public object GetLocals(int stackFrame = 0) => null!;
    public object[] GetStack() => default!;
    public object GetUpvalues(int stackFrame = 0) => null!;
    public object GetWatchValue(Instance? watch) => null!;
    public object GetWatches() => null!;
    public Instance SetBreakpoint(int line, bool isContextDependentBreakpoint) => null!;
    public object SetGlobal(string? name, object? value, int stackFrame) => null!;
    public object SetLocal(string? name, object? value, int stackFrame = 0) => null!;
    public object SetUpvalue(string? name, object? value, int stackFrame = 0) => null!;

    // Events
    public event Action<Instance> BreakpointAdded = null!;
    public event Action<Instance> BreakpointRemoved = null!;
    public event Action<int, object> EncounteredBreak = null!;
    public event Action Resuming = null!;
    public event Action<Instance> WatchAdded = null!;
    public event Action<Instance> WatchRemoved = null!;
}
