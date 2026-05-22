using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class CaptureService : Instance
{
    // Methods
    public object CaptureScreenshot(Delegate? onCaptureReady) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetDeviceInfo() => default!;
    public object PromptSaveCapturesToGallery(object[]? captures, Delegate? resultCallback) => null!;
    public object PromptShareCapture(string? captureContent, string? launchData, Delegate? onAcceptedCallback, Delegate? onDeniedCallback) => null!;
    public object StopVideoCapture() => null!;
    public object TakeScreenshotCaptureAsync(Delegate? onCaptureReady, System.Collections.Generic.Dictionary<string, object> captureParams = null) => null!;
    public object[] CheckUploadCaptureStatusAsync(string? token) => default!;
    public bool InternalCheckPlayabilityAsync(long universeId) => default!;
    public long InternalGetStartPlaceIdAsync(long universeId) => default!;
    public bool PromptCaptureGalleryPermissionAsync(object? captureGalleryPermission) => default!;
    public object[] ReadCapturesFromGalleryAsync(object[]? captureTypeFilters = null, bool readFromAllEligibleExperiences = false) => default!;
    public object[] StartUploadCaptureAsync(object? capture) => default!;
    public object StartVideoCaptureAsync(Delegate? onCaptureReady, System.Collections.Generic.Dictionary<string, object> captureParams = null) => null!;
    public object[] UploadCaptureAsync(object? capture) => default!;

    // Events
    public event Action<object> CaptureBegan = null!;
    public event Action<object> CaptureEnded = null!;
    public event Action<object> UserCaptureSaved = null!;
}
