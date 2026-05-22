using System;

namespace Roblox.Instances;

public class ExecutedRemoteCommand : Object
{
    // Methods
    public object RunMoreCode(string? code, object[]? args) => null!;
    public object SendUpdate(object[]? args) => null!;
    public object Stop() => null!;

    // Events
    public event Action<object[]> ReceivedUpdate = null!;
}
