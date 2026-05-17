using System;
using Roblox.Datatypes;

namespace Roblox.Instances;

public class Player : Instance
{
    // Identity
    public int UserId { get; set; }
    public string DisplayName { get; set; } = null!;
    public int AccountAge { get; set; }

    // Character — now correctly typed as Model
    public Model? Character { get; set; }
    public event Action<Model> CharacterAdded = null!;
    public event Action<Model> CharacterRemoving = null!;
    public void LoadCharacter() { }

    // Teams
    public string TeamColor { get; set; } = null!;
    public bool Neutral { get; set; }

    // Network
    public int Ping { get; set; }

    // Camera
    public float CameraMaxZoomDistance { get; set; }
    public float CameraMinZoomDistance { get; set; }
    public CFrame? RespawnLocation { get; set; }

    // Actions
    public void Kick(string message = "") { }
}
