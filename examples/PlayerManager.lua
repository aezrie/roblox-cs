local PlayerManager = {}
PlayerManager.__index = PlayerManager
function PlayerManager.new()
    local self = setmetatable({}, PlayerManager)
    self._players = game:GetService("Players")
    self._playerCount = 0
    return self
end
function PlayerManager:Initialize()
    print("PlayerManager initializing...")
    self._players.PlayerAdded:Connect(function(...)
        return self:OnPlayerAdded(...)
    end)
    self._players.PlayerRemoving:Connect(function(...)
        return self:OnPlayerRemoving(...)
    end)
end
function PlayerManager:OnPlayerAdded(player)
    self._playerCount = self._playerCount + 1
    print("Player joined: " .. player.Name)
    local character = player and player.Character
    local displayName = player.DisplayName or player.Name
    if character ~= nil then
        print(displayName .. " has a character")
    end
end
function PlayerManager:OnPlayerRemoving(player)
    self._playerCount = self._playerCount - 1
    print("Player left: " .. player.Name)
end
function PlayerManager.GetVersion()
    return "1.0.0"
end
return PlayerManager
