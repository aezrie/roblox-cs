using System;

namespace Roblox.Instances;

public class ValueCurve : Instance
{
    // Properties
    public int Length { get; }
    public string? ValueType { get; } = null!;

    // Methods
    public object GetKeyAtIndex(int index) => null!;
    public object[] GetKeyIndicesAtTime(float time) => default!;
    public object[] GetKeys() => default!;
    public object GetValueAtTime(float time) => null!;
    public object[] InsertKey(object? key) => default!;
    public object[] InsertKeyValue(float time, object? value, object? keyInterpolationMode = null) => default!;
    public int RemoveKeyAtIndex(int startingIndex, int count = 1) => default!;
    public int SetKeys(object[]? keys) => default!;

}
