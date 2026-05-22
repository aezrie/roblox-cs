using System;
using Roblox.Datatypes;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class Lighting : Instance
{
    // Properties
    public Color3 Ambient { get; set; }
    public float Brightness { get; set; }
    public float ClockTime { get; set; }
    public Color3 ColorShiftBottom { get; set; }
    public Color3 ColorShiftTop { get; set; }
    public float EnvironmentDiffuseScale { get; set; }
    public float EnvironmentSpecularScale { get; set; }
    public float ExposureCompensation { get; set; }
    public Color3 FogColor { get; set; }
    public float FogEnd { get; set; }
    public float FogStart { get; set; }
    public float GeographicLatitude { get; set; }
    public bool GlobalShadows { get; set; }
    public Color3 OutdoorAmbient { get; set; }
    public float ShadowSoftness { get; set; }
    public string? TimeOfDay { get; set; } = null!;

    // Methods
    public double GetMinutesAfterMidnight() => default!;
    public Vector3 GetMoonDirection() => default!;
    public float GetMoonPhase() => default!;
    public Vector3 GetSunDirection() => default!;
    public object SetMinutesAfterMidnight(double minutes) => null!;

    // Events
    public event Action<bool> LightingChanged = null!;
}
