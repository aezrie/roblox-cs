using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Model : PVInstance
{
    public BasePart? PrimaryPart { get; set; }
    public CFrame WorldPivot { get; set; }

    public (CFrame Orientation, Vector3 Size) GetBoundingBox() => default;
    public Vector3 GetExtentsSize() => default;

    public void MoveTo(Vector3 position) { }
    public void TranslateBy(Vector3 delta) { }
    public void ScaleTo(float newScaleFactor) { }
    public float GetScale() => default;

    public void MakeJoints() { }
    public void BreakJoints() { }

    public void AddPersistentPlayer(Player player) { }
    public void RemovePersistentPlayer(Player player) { }
    public Player[] GetPersistentPlayers() => null!;
}
