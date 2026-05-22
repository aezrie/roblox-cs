using System;

namespace Roblox.Instances;

public class TestCase : Instance
{
    // Methods
    public object Assert(bool condition, string? message = null, Instance? source = null, int line = 0) => null!;
    public object EndTest(string? message = null, Instance? source = null, int line = 0) => null!;
    public object Message(string? text, Instance? source = null, int line = 0) => null!;
    public object Require(bool condition, string? message = null, Instance? source = null, int line = 0) => null!;

}
