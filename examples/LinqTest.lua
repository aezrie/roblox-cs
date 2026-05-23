local LinqTest = {}
LinqTest.__index = LinqTest
function LinqTest.new()
    local self = setmetatable({}, LinqTest)
    return self
end
function LinqTest:Run()
    local parts = {}
    local visibleParts = function()
        local _r = {}
        for _, _v in parts do
            if function(p)
                return p.Transparency < 1
            end(_v) then
                table.insert(_r, _v)
            end
        end
        return _r
    end()
    local partNames = function()
        local _r = {}
        for _, _v in parts do
            if function(p)
                return p.Parent == nil
            end(_v) then
                table.insert(_r, function(p)
                    return p.Name
                end(_v))
            end
        end
        return _r
    end()
    local hasAny = function()
        local _r = false
        for _, _v in parts do
            if function(p)
                return p.Name == "Target"
            end(_v) then
                _r = true
                return _r
            end
        end
        return _r
    end()
    local allVisible = function()
        local _r = true
        for _, _v in parts do
            if not function(p)
                return p.Transparency == 0
            end(_v) then
                _r = false
                return _r
            end
        end
        return _r
    end()
    local first = function()
        local _r = nil
        for _, _v in parts do
            _r = _v
            return _r
        end
        return _r
    end()
    Extensions.MyCustomExtension(parts)
    table.insert(parts, Instance.new("Part"))
    local count = #parts
    local firstPart = parts[0 + 1]
    table.remove(parts, 0 + 1)
    table.clear(parts)
end
local Extensions = {}
function Extensions.MyCustomExtension(list)
    print("Extension called!")
end
return Extensions
