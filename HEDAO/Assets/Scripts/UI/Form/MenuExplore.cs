using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;
using System.Collections.Generic;
using System.Linq;
using Cfg;

public class MenuExplore : UIBase
{
    private List<object> m_TeamList = new List<object>();
    public List<object> m_NodeList = new List<object>();

    public Dictionary<long, Role> RoleTeamSet => GameMgr.Save.Data.TeamDict;
    public Dictionary<long, Role> DiscipleDict => GameMgr.Save.Data.RoleDict;

    public new FGUIMenuExplore View => base.View as FGUIMenuExplore;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        View.m_list_role.itemRenderer = OnRenderRole;
        View.m_list_node.itemRenderer = OnRenderNode;
    }

    protected override void OnShow()
    {
        base.OnShow();

        m_TeamList = RoleTeamSet.Values.AsEnumerable<object>().ToList();
        View.m_list_role.RefreshList(m_TeamList);

        foreach(var cfg in GameMgr.Cfg.TbExploreNodeCfg.DataList.GetRandom(3))
        {
            m_NodeList.Add(new BattleNode(cfg.Id));
        }
        View.m_list_node.RefreshList(m_NodeList);
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

    private void OnRenderNode(int index, GObject item, object data)
    {
        var node = data as ExploreNode;
        item.text = string.Format("{0}\n{1}", node.Cfg.Name, node.Cfg.Desc);
        item.onClick.Set(node.OnSelected);
    }
}
