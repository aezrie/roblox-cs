using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Terrain : BasePart
{
    // Properties
    public object? MaxExtents { get; } = null!;
    public Color3 WaterColor { get; set; }
    public float WaterReflectance { get; set; }
    public float WaterTransparency { get; set; }
    public float WaterWaveSize { get; set; }
    public float WaterWaveSpeed { get; set; }

    // Methods
    public Vector3 CellCenterToWorld(int x, int y, int z) => default!;
    public Vector3 CellCornerToWorld(int x, int y, int z) => default!;
    public object Clear() => null!;
    public object ClearVoxelsAsyncbeta(object? region, object[]? channelIds) => null!;
    public object CopyRegion(object? region) => null!;
    public int CountCells() => default!;
    public object FillBall(Vector3 center, float radius, object? material) => null!;
    public object FillBlock(CFrame cframe, Vector3 size, object? material) => null!;
    public object FillCylinder(CFrame cframe, float height, float radius, object? material) => null!;
    public object FillRegion(object? region, float resolution, object? material) => null!;
    public object FillWedge(CFrame cframe, Vector3 size, object? material) => null!;
    public object GetBaseMaterialSlotIndex(object? baseMaterial) => null!;
    public int GetFirstCustomMaterialSlotIndex() => default!;
    public Color3 GetMaterialColor(object? material) => default!;
    public object[] GetMaterialSlot(int slotIndex) => default!;
    public object IterateVoxelsAsyncbeta(object? region, int resolution, object[]? channelIds) => null!;
    public object ModifyVoxelsAsyncbeta(object? region, int resolution, object[]? channelIds) => null!;
    public object PasteRegion(object? region, object? corner, bool pasteEmptyCells) => null!;
    public System.Collections.Generic.Dictionary<string, object> ReadVoxelChannels(object? region, float resolution, object[]? channelIds) => default!;
    public object[] ReadVoxels(object? region, float resolution) => default!;
    public object ReadVoxelsAsyncbeta(object? region, int resolution, object[]? channelIds) => null!;
    public object ReplaceMaterial(object? region, float resolution, object? sourceMaterial, object? targetMaterial) => null!;
    public object ResetMaterialSlot(int slotIndex) => null!;
    public object SetMaterialColor(object? material, Color3 value) => null!;
    public object SetMaterialSlot(int slotIndex, object? baseMaterial, string? materialVariant, Color3 color) => null!;
    public Vector3 WorldToCell(Vector3 position) => default!;
    public Vector3 WorldToCellPreferEmpty(Vector3 position) => default!;
    public Vector3 WorldToCellPreferSolid(Vector3 position) => default!;
    public object WriteVoxelChannels(object? region, float resolution, System.Collections.Generic.Dictionary<string, object> channels) => null!;
    public object WriteVoxels(object? region, float resolution, object[]? materials, object[]? occupancy) => null!;
    public object WriteVoxelsAsyncbeta(object? region, int resolution, object[]? channelIds) => null!;

}
