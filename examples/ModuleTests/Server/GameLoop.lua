local MathUtils = require(game:GetService("ReplicatedStorage").Utils.MathUtils)
local GameLoop = {}
GameLoop.__index = GameLoop
function GameLoop.new()
    local self = setmetatable({}, GameLoop)
    local result = MathUtils.Add(5, 10)
    print("MathUtils result: " .. result)
    return self
end
return GameLoop
