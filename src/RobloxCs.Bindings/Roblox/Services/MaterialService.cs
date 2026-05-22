using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class MaterialService : Instance
{
    // Methods
    public string GetBaseMaterialOverride(object? material) => default!;
    public object GetMaterialVariant(object? material, string? name) => null!;
    public object SetBaseMaterialOverride(object? material, string? name) => null!;

}
