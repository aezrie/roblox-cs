using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class IncrementalPatchBuilder : Instance
{
    // Properties
    public bool AddPathsToBundle { get; set; }
    public double BuildDebouncePeriod { get; set; }
    public bool HighCompression { get; set; }
    public bool SerializePatch { get; set; }
    public bool UseFileLevelCompressionInsteadOfChunk { get; set; }
    public bool ZstdCompression { get; set; }

}
