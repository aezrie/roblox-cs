using System;
using Roblox.Datatypes;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class TextService : Instance
{
    // Methods
    public Vector2 GetTextSize(string? @string, int fontSize, object? font, Vector2 frameSize) => default!;
    public object FilterAndTranslateStringAsync(string? stringToFilter, long fromUserId, object[]? targetLocales, object? textContext = null) => null!;
    public object FilterStringAsync(string? stringToFilter, long fromUserId, object? textContext = null) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetFamilyInfoAsync(object? assetId) => default!;
    public Vector2 GetTextBoundsAsync(object? @params) => default!;
    public float GetTextSizeOffsetAsync(int fontSize, object? font) => default!;

}
