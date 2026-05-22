print("Server started!")
game.Players.PlayerAdded:Connect(function(player)
    print("Player joined: " .. player.Name)
    local character = player and player.Character
    local displayName = player.DisplayName or player.Name
    print("Display name: " .. displayName)
    if character ~= nil then
        print("Character exists")
    else
        print("Waiting for character...")
    end
end)
game.Players.PlayerRemoving:Connect(function(player)
    print("Player left: " .. player.Name)
end)
for _, p in game.Players:GetPlayers() do
    print("Online: " .. p.Name)
end
