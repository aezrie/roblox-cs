namespace Roblox;

public static class Game
{
    public static T GetService<T>() where T : class => null!;
    public static Roblox.Services.Workspace Workspace => null!;
}
