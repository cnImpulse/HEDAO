using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;
using System.Collections.Generic;
using System.Linq;
using Cfg;

public class MenuExplore : UIBase
{
    public Dictionary<long, PlayerRole> Team => GameMgr.Explore.Data.Team;
    public ExploreDate Data => GameMgr.Explore.Data;

    public new FGUIMenuExplore View => base.View as FGUIMenuExplore;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        View.m_btn_prepare.onClick.Set(OnClickParepare);

        View.m_list_role.itemRenderer = OnRenderRole;
    }

    protected override void OnShow()
    {
        base.OnShow();

        View.m_list_role.RefreshList(Team.Values.ToList());
    }

    private void OnRenderRole(int index, GObject obj, object data)
    {
        var role = data as Role;
        var item = obj as FGUIRoleItem;
        item.m_bar_hp.value = role.Attr.GetAttrValue(EAttrType.HP);
        item.m_bar_hp.max = role.Attr.GetAttrValue(EAttrType.MaxHP);
        item.m_bar_qi.value = role.Attr.GetAttrValue(EAttrType.QI);
        item.m_bar_qi.max = role.Attr.GetAttrValue(EAttrType.MaxQI);

        var btn = item.m_btn_role as FGUIBtnRole;
        btn.mode = ButtonMode.Common;
        btn.Refresh(role);
    }

    private void OnClickParepare()
    {
        if (Team.Count > 0)
        {
            GameMgr.UI.ShowUI(UIName.MenuRole, new OpenMenuRoleData{RoleList = Team.Values.Cast<Role>().ToList()});
        }
    }
}
