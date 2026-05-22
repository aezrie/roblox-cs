using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class RunService : Instance
{
    // Properties
    public long FrameNumber { get; }

    // Methods
    public object BindToRenderStep(string? name, int priority, Delegate? function) => null!;
    public object BindToSimulation(Delegate? function, object? frequency = null, int priority = default) => null!;
    public object GetPredictionStatus(Instance? context) => null!;
    public bool IsClient() => default!;
    public bool IsRunMode() => default!;
    public bool IsRunning() => default!;
    public bool IsServer() => default!;
    public bool IsStudio() => default!;
    public object SetPredictionMode(Instance? context, object? mode) => null!;
    public object UnbindFromRenderStep(string? name) => null!;

    // Events
    public event Action<double> Heartbeat = null!;
    public event Action<double, object[], System.Collections.Generic.Dictionary<string, object>> Misprediction = null!;
    public event Action<double> PostSimulation = null!;
    public event Action<double> PreAnimation = null!;
    public event Action<double> PreRender = null!;
    public event Action<double> PreSimulation = null!;
    public event Action<double> RenderStepped = null!;
    public event Action<double> Rollback = null!;
    public event Action<double, double> Stepped = null!;
}
