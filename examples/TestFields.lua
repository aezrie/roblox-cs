local TestFields = {}
TestFields.__index = TestFields
function TestFields.new()
    local self = setmetatable({}, TestFields)
    self.Score = 10
    self.Name = "Guest"
    self.Score = 20
    return self
end
return TestFields
