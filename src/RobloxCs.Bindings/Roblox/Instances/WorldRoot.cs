using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class WorldRoot : Model
{
    // Methods
    public bool ArePartsTouchingOthers(object? partList, float overlapIgnored = default) => default!;
    public object Blockcast(CFrame cframe, Vector3 size, Vector3 direction, object? @params = null) => null!;
    public object BulkMoveTo(object? partList, object[]? cframeList, object? eventMode = null) => null!;
    public object GetPartBoundsInBox(CFrame cframe, Vector3 size, object? overlapParams = null) => null!;
    public object GetPartBoundsInRadius(Vector3 position, float radius, object? overlapParams = null) => null!;
    public object GetPartsInPart(object? part, object? overlapParams = null) => null!;
    public object Raycast(Vector3 origin, Vector3 direction, object? raycastParams = null) => null!;
    public object Shapecast(object? part, Vector3 direction, object? @params = null) => null!;
    public object Spherecast(Vector3 position, float radius, Vector3 direction, object? @params = null) => null!;

}
