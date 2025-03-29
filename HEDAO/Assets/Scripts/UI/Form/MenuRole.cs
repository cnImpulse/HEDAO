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
    
    private static List<EAttrType> AttrList = new List<EAttrType>()
    {
        EAttrType.MaxHP, EAttrType.MaxQI, EAttrType.SPD, EAttrType.STR,
        EAttrType.TPO, EAttrType.SSI, EAttrType.FAS
    };
    
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
        var attr = Role.BattleAttr;
        var info = $"姓名：{Role.Name}\n";
        info += $"年龄：{attr.GetAttr(EAttrType.Age)} 寿命：{attr.GetAttr(EAttrType.Life)}\n";
        foreach (var attrType in AttrList)
        {
            info += $"{attrType.GetName()}：{attr.GetAttr(attrType)} \n";
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
