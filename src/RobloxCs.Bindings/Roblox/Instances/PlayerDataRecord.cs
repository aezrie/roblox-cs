using System;

namespace Roblox.Instances;

public class PlayerDataRecord : Instance
{
    // Properties
    public long CreatedTime { get; }
    public bool DefaultRecordName { get; }
    public bool Dirty { get; }
    public object? Error { get; } = null!;
    public long FlushedTime { get; }
    public long LoadedTime { get; }
    public long ModifiedTime { get; }
    public bool NewRecord { get; }
    public bool Readable { get; }
    public string? RecordName { get; } = null!;
    public bool Writable { get; }

    // Methods
    public object GetPlayer() => null!;
    public object GetValue(string? key) => null!;
    public object GetValueChangedSignal(string? key) => null!;
    public object RemoveValue(string? key) => null!;
    public object SetValue(string? key, object? value) => null!;
    public object ReleaseAsync() => null!;
    public object RequestFlushAsync() => null!;

    // Events
    public event Action<string, object> Changed = null!;
    public event Action<bool, object> Flushed = null!;
    public event Action<bool, object> Loaded = null!;
}
