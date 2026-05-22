local ApiTest = {}
ApiTest.__index = ApiTest
function ApiTest.new()
    local self = setmetatable({}, ApiTest)
    return self
end
function ApiTest:RunTest()
    local players = game:GetService("Players")
    players.PlayerAdded:Connect(function(player)
        print("Player joined!")
    end)
    local allPlayers = players:GetPlayers()
    print("Max players: " .. players.MaxPlayers)
    local part = Instance.new("Part")
    part.Name = "TestPart"
    part.Position = Vector3.new(0, 10, 0)
    part.Parent = workspace
end
return ApiTest
