local Point = {}
Point.__index = Point
function Point:Clone()
    return setmetatable(table.clone(self), Point)
end
function Point.new()
    local self = setmetatable({}, Point)
    return self
end
local Color = {}
Color.__index = Color
function Color:Clone()
    return setmetatable(table.clone(self), Color)
end
function Color.new()
    local self = setmetatable({}, Color)
    return self
end
local Phase4Test = {}
Phase4Test.__index = Phase4Test
function Phase4Test.new()
    local self = setmetatable({}, Phase4Test)
    return self
end
function Phase4Test:Run()
    local p1 = Point.new()
    local p2 = p1:Clone()
    p2.X = 100
    self:PrintPoint(p1:Clone())
    local p3 = function(_c)
        _c.Y = 50
        return _c
    end(p1:Clone())
    local part = Instance.new("Part")
    if part:IsA("BasePart") then
        local bp = part
        print("It is a BasePart: " .. bp.Name)
    end
    local obj = part
    if obj:IsA("BasePart") then
        local p = obj
        print("Switch: BasePart " .. p.Name)
    else
        print("Switch: default")
    end
end
function Phase4Test:PrintPoint(p)
    print(string.format("Point: %s, %s", p.X, p.Y))
end
return Phase4Test
