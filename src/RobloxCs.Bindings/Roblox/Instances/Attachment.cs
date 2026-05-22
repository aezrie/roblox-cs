using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Attachment : Instance
{
    // Properties
    public Vector3 Axis { get; set; }
    public CFrame CFrame { get; set; }
    public Vector3 SecondaryAxis { get; set; }
    public bool Visible { get; set; }
    public Vector3 WorldAxis { get; set; }
    public CFrame WorldCFrame { get; set; }
    public Vector3 WorldSecondaryAxis { get; set; }

    // Methods
    public object GetConstraints() => null!;

}
