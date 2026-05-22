using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Pose : PoseBase
{
    // Properties
    public CFrame CFrame { get; set; }

    // Methods
    public object AddSubPose(Instance? pose) => null!;
    public object GetSubPoses() => null!;
    public object RemoveSubPose(Instance? pose) => null!;

}
