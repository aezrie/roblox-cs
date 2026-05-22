using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class HumanoidDescription : Instance
{
    // Properties
    public string? BackAccessory { get; set; } = null!;
    public float BodyTypeScale { get; set; }
    public long ClimbAnimation { get; set; }
    public float DepthScale { get; set; }
    public long Face { get; set; }
    public string? FaceAccessory { get; set; } = null!;
    public long FallAnimation { get; set; }
    public string? FrontAccessory { get; set; } = null!;
    public long GraphicTShirt { get; set; }
    public string? HairAccessory { get; set; } = null!;
    public string? HatAccessory { get; set; } = null!;
    public long Head { get; set; }
    public Color3 HeadColor { get; set; }
    public float HeadScale { get; set; }
    public float HeightScale { get; set; }
    public long IdleAnimation { get; set; }
    public long JumpAnimation { get; set; }
    public long LeftArm { get; set; }
    public Color3 LeftArmColor { get; set; }
    public long LeftLeg { get; set; }
    public Color3 LeftLegColor { get; set; }
    public long MoodAnimation { get; set; }
    public string? NeckAccessory { get; set; } = null!;
    public long Pants { get; set; }
    public float ProportionScale { get; set; }
    public long RightArm { get; set; }
    public Color3 RightArmColor { get; set; }
    public long RightLeg { get; set; }
    public Color3 RightLegColor { get; set; }
    public long RunAnimation { get; set; }
    public long Shirt { get; set; }
    public string? ShouldersAccessory { get; set; } = null!;
    public bool StaticFacialAnimation { get; set; }
    public long SwimAnimation { get; set; }
    public long Torso { get; set; }
    public Color3 TorsoColor { get; set; }
    public bool UseAvatarSettings { get; set; }
    public string? WaistAccessory { get; set; } = null!;
    public long WalkAnimation { get; set; }
    public float WidthScale { get; set; }

    // Methods
    public object AddEmote(string? name, long assetId) => null!;
    public object[] GetAccessories(bool includeRigidAccessories) => default!;
    public System.Collections.Generic.Dictionary<string, object> GetEmotes() => default!;
    public object[] GetEquippedEmotes() => default!;
    public object RemoveEmote(string? name) => null!;
    public object SetAccessories(object[]? accessories, bool includeRigidAccessories) => null!;
    public object SetEmotes(System.Collections.Generic.Dictionary<string, object> emotes) => null!;
    public object SetEquippedEmotes(object[]? equippedEmotes) => null!;

    // Events
    public event Action<System.Collections.Generic.Dictionary<string, object>> EmotesChanged = null!;
    public event Action<object[]> EquippedEmotesChanged = null!;
}
