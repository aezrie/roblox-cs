using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class ScreenshotHud : Instance
{
    // Properties
    public object? CameraButtonIcon { get; set; } = null!;
    public UDim2 CameraButtonPosition { get; set; }
    public UDim2 CloseButtonPosition { get; set; }
    public bool CloseWhenScreenshotTaken { get; set; }
    public bool HideCoreGuiForCaptures { get; set; }
    public bool HidePlayerGuiForCaptures { get; set; }
    public bool Visible { get; set; }

}
