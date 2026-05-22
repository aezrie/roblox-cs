using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class EncodingService : Instance
{
    // Methods
    public object Base64Decode(object? input) => null!;
    public object Base64Encode(object? input) => null!;
    public object CompressBuffer(object? input, object? algorithm, int compressionLevel = 1) => null!;
    public object ComputeBufferHash(object? input, object? algorithm) => null!;
    public string ComputeStringHash(string? input, object? algorithm) => default!;
    public object DecompressBuffer(object? input, object? algorithm) => null!;
    public object GetDecompressedBufferSize(object? input, object? algorithm) => null!;

}
