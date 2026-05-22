using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class Stats : Instance
{
    // Properties
    public int ContactsCount { get; }
    public float DataReceiveKbps { get; }
    public float DataSendKbps { get; }
    public float FrameTime { get; }
    public float HeartbeatTime { get; }
    public int InstanceCount { get; }
    public bool MemoryTrackingEnabled { get; }
    public int MovingPrimitivesCount { get; }
    public float PhysicsReceiveKbps { get; }
    public float PhysicsSendKbps { get; }
    public float PhysicsStepTime { get; }
    public int PrimitivesCount { get; }
    public float RenderCPUFrameTime { get; }
    public float RenderGPUFrameTime { get; }
    public int SceneDrawcallCount { get; }
    public int SceneTriangleCount { get; }
    public int ShadowsDrawcallCount { get; }
    public int ShadowsTriangleCount { get; }
    public int UI2DDrawcallCount { get; }
    public int UI2DTriangleCount { get; }
    public int UI3DDrawcallCount { get; }
    public int UI3DTriangleCount { get; }

    // Methods
    public int GetHarmonyQualityLevel() => default!;
    public object[] GetMemoryCategoryNames() => default!;
    public object[] GetMemoryUsageMbAllCategories() => default!;
    public float GetMemoryUsageMbForTag(object? tag) => default!;
    public float GetTotalMemoryUsageMb() => default!;
    public object ResetHarmonyMemoryTarget() => null!;
    public object SetHarmonyMemoryTarget(int targetMB) => null!;

}
