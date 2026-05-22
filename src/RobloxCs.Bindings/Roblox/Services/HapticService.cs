using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class HapticService : Instance
{
    // Methods
    public object[] GetMotor(object? inputType, object? vibrationMotor) => default!;
    public bool IsMotorSupported(object? inputType, object? vibrationMotor) => default!;
    public bool IsVibrationSupported(object? inputType) => default!;
    public object SetMotor(object? inputType, object? vibrationMotor, object[]? vibrationValues) => null!;

}
