using System;

namespace Roblox.Instances;

public class MarkerCurve : Instance
{
    // Properties
    public int Length { get; }

    // Methods
    public System.Collections.Generic.Dictionary<string, object> GetMarkerAtIndex(int index) => default!;
    public object[] GetMarkers() => default!;
    public object[] InsertMarkerAtTime(float time, string? marker) => default!;
    public int RemoveMarkerAtIndex(int startingIndex, int count = 1) => default!;

}
