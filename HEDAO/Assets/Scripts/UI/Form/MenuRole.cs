using System;
using System.Collections.Generic;
using Cfg;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class MenuRole : UIBase
{
    public Role Role;
    public new FGUIMenuRole View => base.View as FGUIMenuRole;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        Role = userData as Role;
        // View.m_list_role.m_list.itemRenderer = OnRenderRole;
        // View.m_list_role.m_list.RefreshList();
    }

    protected override void OnShow()
    {
        base.OnShow();

        RefreshRole();
    }
    
    private void RefreshRole()
    {
        var attrInfo = GetRoleAttrInfo(Role);
        var bookInfo = GetRoleBookInfo(Role);
        var skillInfo = GetRoleSkillInfo(Role);
        View.m_txt_role.text = attrInfo + '\n' + bookInfo + '\n' + skillInfo;
        View.m_rader.Refresh(Role);
    }

    private string GetRoleAttrInfo(Role role)
    {
        var attr = role.BattleAttr;
        var info = $"姓名：{role.Name}\n";
        info += $"年龄：{attr.GetAttr(EAttrType.Age)} 寿命：{attr.GetAttr(EAttrType.Life)}\n";

        var levelCfg = GameMgr.Cfg.Tables.TbLevelCfg.Get(role.Level);
        info += $"境界：{levelCfg.Name} {EAttrType.Exp.GetName()}: {attr.GetAttr(EAttrType.Exp)}/{levelCfg.Exp}\n";
        
        var attrList = GameMgr.Cfg.Tables.TbMisc.AttrTypeList;
        for (int i = 0; i < attrList.Count; i++)
        {
            var attrType= attrList[i];
            info += $"{attrType.GetName()}：{attr.GetAttr(attrType)} ";
            if (i % 2 == 1)
            {
                info += '\n';
            }
        }

        return info;
    }

    private string GetRoleBookInfo(Role role)
    {
        string info = string.Empty;
        foreach (var bookType in GameMgr.Cfg.Tables.TbMisc.BookTypeList)
        {
            if (role.BookDict.TryGetValue(bookType, out var id))
            {
                var cfg = GameMgr.Cfg.Tables.TbGongFaCfg.Get(id);
                info += string.Format("{0}:{1}  ", bookType.GetName(), cfg.Name);
            }
            else
            {
                info += string.Format("{0}:{1}  ", bookType.GetName(), "无");
            }
        }
        return info;
    }

    private string GetRoleSkillInfo(Role role)
    {
        string info = "技能: ";
        foreach (var id in role.SkillSet)
        {
            var cfg = GameMgr.Cfg.Tables.TbSkillCfg.Get(id);
            info += cfg.Name;
        }

        return info;
    }
}
