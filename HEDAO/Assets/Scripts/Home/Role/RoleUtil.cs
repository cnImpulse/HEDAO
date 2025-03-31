using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public static class RoleUtil
{
    public static string GetRoleInfo(Role role)
    {
        var attrInfo = GetRoleAttrInfo(role);
        var bookInfo = GetRoleBookInfo(role);
        var skillInfo = GetRoleSkillInfo(role);
        return attrInfo + '\n' + bookInfo + '\n' + skillInfo;
    }

    public static string GetRoleAttrInfo(Role role)
    {
        var attr = role.Attr;
        var info = $"姓名：{role.Name} {GetRoleTagInfo(role)}\n";

        info += $"年龄：{attr.GetAttrValue(EAttrType.Age)} 寿命：{attr.GetAttrValue(EAttrType.Life)}\n";

        var levelCfg = GameMgr.Cfg.TbLevelCfg.Get(role.Level);
        info += $"境界：{levelCfg.Name} {EAttrType.Exp.GetName()}: {attr.GetAttrValue(EAttrType.Exp)}/{levelCfg.UpExp} ";
        info += $"{EAttrType.Break.GetName()}: {attr.GetAttrValue(EAttrType.Break)}/{levelCfg.UpBreak}\n";

        var attrList = GameMgr.Cfg.TbMisc.AttrTypeList;
        for (int i = 0; i < attrList.Count; i++)
        {
            var attrType = attrList[i];
            info += $"{attrType.GetName()}：{attr.GetAttrValue(attrType)} ";
            if (i % 2 == 1)
            {
                info += '\n';
            }
        }

        return info;
    }

    public static string GetRoleTagInfo(Role role)
    {
        string info = "天赋: ";
        foreach (var id in role.TagSet)
        {
            var cfg = GameMgr.Cfg.TbRoleTagCfg.Get(id);
            info += string.Format("{0} ", cfg.Name);
        }

        return info;
    }

    public static string GetRoleBookInfo(Role role)
    {
        string info = string.Empty;
        foreach (var bookType in GameMgr.Cfg.TbMisc.BookTypeList)
        {
            if (role.BookDict.TryGetValue(bookType, out var id))
            {
                var cfg = GameMgr.Cfg.TbGongFaCfg.Get(id);
                info += string.Format("{0}:{1}  ", bookType.GetName(), cfg.Name);
            }
            else
            {
                info += string.Format("{0}:{1}  ", bookType.GetName(), "无");
            }
        }
        return info;
    }

    public static string GetRoleSkillInfo(Role role)
    {
        string info = "技能: ";
        foreach (var id in role.SkillSet)
        {
            var cfg = GameMgr.Cfg.TbSkillCfg.Get(id);
            info += cfg.Name;
        }

        return info;
    }
}