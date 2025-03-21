local CodePath = "/../Form/"

function codegen(className, path)
    local str = [[
using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class ]]..className..[[ : UIBase
{
    public new FGUI]]..className..[[ View;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

    }

    protected override void OnShow()
    {
        base.OnShow();

    }
}
]]

    path = path..className..'.cs'
    local file, err = io.open(path, "r")
    if file then
        file:close()
        return
    end

    file, err = io.open(path, "w")
    if not file then
        fprint("Failed to creat file: " .. err)
        return
    end

    file:write(str)
    file:close()
end

function GenerateUINameFile(path, uiNames)
    local content = [[
public static partial class UIName
{
]]

    -- 添加每个UI名称常量
    for _, name in ipairs(uiNames) do
        content = content .. string.format('        public const string %s = "%s";\n', name, name)
    end

    content = content .. [[
}
]]

    -- 写入文件
    local file, err = io.open(path, "w")
    if not file then
        print("Failed to create file: " .. err)
        return
    end

    file:write(content)
    file:close()
    print("File generated successfully: " .. path)
end

function GenerateUICfgFile(path, uiNames)
    local content = [[
using System;
using System.Collections.Generic;
using FGUI.Common;

public static partial class UICfg
{
    static UICfg()
    {
]]

    -- 添加每个UI配置项
    for _, name in ipairs(uiNames) do
    content = content .. string.format('        cfg[UIName.%s] = new UICfgItem(typeof(%s), FGUI%s.URL);\n', name, name, name)
    end

    content = content .. [[
    }
}
]]

    -- 写入文件（覆盖旧文件）
    local file, err = io.open(path, "w")
    if not file then
        print("Failed to create file: " .. err)
        return
    end

    file:write(content)
    file:close()
    print("File generated successfully: " .. path)
end

function StartsWith(string, start)
    return string.sub(string, 1, string.len(start)) == start
end

function CheckPrefix(str, list)
    for _, prefix in ipairs(list) do
        if StartsWith(str, prefix) then
            return true, prefix
        end
    end
    return false
end

local ExportList = {"Menu", "Hud"}
---@param handler CS.FairyEditor.PublishHandler
function onPublish(handler)
    ---@type CS.FairyEditor.PublishHandler.ClassInfo[]
    local classes = handler:CollectClasses(false, false)

    local uiNames = {}
    local classCnt = classes.Count
    local path = handler.exportCodePath..CodePath
    for i = 0, classCnt - 1 do
        local classInfo = classes[i]
        if CheckPrefix(classInfo.resName, ExportList) then
            fprint(classInfo.resName)
            codegen(classInfo.resName, path)
            table.insert(uiNames, classInfo.resName)
        end
    end

    local uiNameFilePath = handler.exportCodePath.."/UIName.cs"
    GenerateUINameFile(uiNameFilePath, uiNames)
    GenerateUICfgFile(handler.exportCodePath.."/UICfg.cs", uiNames)
    
    fprint(path)
end