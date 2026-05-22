local TestNoConstructor = {}
TestNoConstructor.__index = TestNoConstructor
function TestNoConstructor.new()
    local self = setmetatable({}, TestNoConstructor)
    self.Score = 15
    self.Name = "Player1"
    return self
end
return TestNoConstructor
