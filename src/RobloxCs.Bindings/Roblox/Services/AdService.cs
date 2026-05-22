using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class AdService : Instance
{
    // Methods
    public object CreateAdRewardFromDevProductId(long devProductId) => null!;
    public object RegisterDisclosureButton(object? disclosureButton, string? adIntegrationPlacementId) => null!;
    public object UnregisterAdOpportunity(Instance? instance) => null!;
    public System.Collections.Generic.Dictionary<string, object> GetAdAvailabilityNowAsync(object? adFormat) => default!;
    public System.Collections.Generic.Dictionary<string, object> GetCampaignEligibilityAsync(string? campaignId, object? player = null) => default!;
    public object RegisterAdOpportunityAsync(Instance? instance, object? placementId) => null!;
    public object ShowRewardedVideoAdAsync(object? player, object? reward, object? placementId) => null!;

}
