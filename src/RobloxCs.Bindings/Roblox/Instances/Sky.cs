using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Sky : Instance
{
    // Properties
    public bool CelestialBodiesShown { get; set; }
    public float MoonAngularSize { get; set; }
    public string? MoonTextureContent { get; set; } = null!;
    public object? MoonTextureId { get; set; } = null!;
    public string? SkyboxBackContent { get; set; } = null!;
    public object? SkyboxBk { get; set; } = null!;
    public object? SkyboxDn { get; set; } = null!;
    public string? SkyboxDownContent { get; set; } = null!;
    public string? SkyboxFrontContent { get; set; } = null!;
    public object? SkyboxFt { get; set; } = null!;
    public string? SkyboxLeftContent { get; set; } = null!;
    public object? SkyboxLf { get; set; } = null!;
    public Vector3 SkyboxOrientation { get; set; }
    public string? SkyboxRightContent { get; set; } = null!;
    public object? SkyboxRt { get; set; } = null!;
    public object? SkyboxUp { get; set; } = null!;
    public string? SkyboxUpContent { get; set; } = null!;
    public int StarCount { get; set; }
    public float SunAngularSize { get; set; }
    public string? SunTextureContent { get; set; } = null!;
    public object? SunTextureId { get; set; } = null!;

}
