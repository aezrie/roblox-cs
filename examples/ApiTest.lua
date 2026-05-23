local ApiTest = {}
ApiTest.__index = ApiTest
function ApiTest.new()
    local self = setmetatable({}, ApiTest)
    return self
end
function ApiTest:RunTest()
    local players = game:GetService("Players")
    players.PlayerAdded:Connect(function(player)
        task.spawn(function()
            print("Player joined!")
            self:DoSomethingAsync()
        end)
    end)
    local allPlayers = players:GetPlayers()
    print("Max players: " .. players.MaxPlayers)
    local part = Instance.new("Part")
    part.Name = "TestPart"
    part.Position = Vector3.new(0, 10, 0)
    part.Parent = workspace
    local name = part and part.Name
    local nested = part and part.Parent and part.Parent.Name
    print("Part name: " .. name)
    self:DoSomethingAsync()
end
function ApiTest:DoSomethingAsync()
    print("Doing something async...")
end
return ApiTest
