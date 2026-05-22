using System;
using Roblox;

namespace Roblox.Services;

[RobloxService]
public class SocialService : Instance
{
    // Methods
    public object GetPlayersByPartyId(string? partyId) => null!;
    public object HideSelfView() => null!;
    public object PromptGameInvite(Instance? player, Instance? experienceInviteOptions = null) => null!;
    public object PromptPhoneBook(Instance? player, string? tag) => null!;
    public object ShowSelfView(object? selfViewPosition = null) => null!;
    public bool CanSendCallInviteAsync(Instance? player) => default!;
    public bool CanSendGameInviteAsync(Instance? player, long recipientId = 0) => default!;
    public object GetEventRsvpStatusAsync(string? eventId) => null!;
    public object GetExperienceEventAsync(string? eventId) => null!;
    public object[] GetPartyAsync(string? partyId) => default!;
    public object[] GetUpcomingExperienceEventsAsync() => default!;
    public object PromptFeedbackSubmissionAsync() => null!;
    public object[] PromptLinkSharingAsync(object? player, System.Collections.Generic.Dictionary<string, object> options = null) => default!;
    public object PromptRsvpToEventAsync(string? eventId) => null!;

    // Callbacks
    public Func<string, object[], Instance>? OnCallInviteInvoked { get; set; }

    // Events
    public event Action<Instance, object> CallInviteStateChanged = null!;
    public event Action<Instance, object[]> GameInvitePromptClosed = null!;
    public event Action<Instance> PhoneBookPromptClosed = null!;
    public event Action<object> ShareSheetClosed = null!;
}
