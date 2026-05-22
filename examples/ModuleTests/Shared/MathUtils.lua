local MathUtils = {}
MathUtils.__index = MathUtils
function MathUtils.new()
    local self = setmetatable({}, MathUtils)
    return self
end
function MathUtils.Add(a, b)
    return a + b
end
return MathUtils
