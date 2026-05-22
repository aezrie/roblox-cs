using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class AnalyticsService : Instance
{
    // Methods
    public int GetDurationLoggerTimestamp() => default!;
    public object LogCustomEvent(object? player, string? eventName, double value = 1, System.Collections.Generic.Dictionary<string, object> customFields = null) => null!;
    public object LogEconomyEvent(object? player, object? flowType, string? currencyType, float amount, float endingBalance, string? transactionType, string? itemSku = null, System.Collections.Generic.Dictionary<string, object> customFields = null) => null!;
    public object LogFunnelStepEvent(object? player, string? funnelName, string? funnelSessionId = null, int step = 1, string? stepName = null, System.Collections.Generic.Dictionary<string, object> customFields = null) => null!;
    public object LogOnboardingFunnelStepEvent(object? player, int step, string? stepName = null, System.Collections.Generic.Dictionary<string, object> customFields = null) => null!;
    public object LogProgressionCompleteEvent(object? player, string? progressionPathName, int level, string? levelName = null, System.Collections.Generic.Dictionary<string, object> customFields = null) => null!;
    public object LogProgressionEvent(object? player, string? progressionPathName, object? status, int level, string? levelName = null, System.Collections.Generic.Dictionary<string, object> customFields = null) => null!;
    public object LogProgressionFailEvent(object? player, string? progressionPathName, int level, string? levelName = null, System.Collections.Generic.Dictionary<string, object> customFields = null) => null!;
    public object LogProgressionStartEvent(object? player, string? progressionPathName, int level, string? levelName = null, System.Collections.Generic.Dictionary<string, object> customFields = null) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetPlayerSegmentsAsync(object? player) => default!;

}
