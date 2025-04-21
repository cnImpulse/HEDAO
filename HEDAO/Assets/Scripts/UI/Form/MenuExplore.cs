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

        View.m_list_role.itemRenderer = OnRenderRole;
        View.m_list_node.itemRenderer = OnRenderNode;
    }

    protected override void OnShow()
    {
        base.OnShow();

        View.m_list_role.RefreshList(Team.Values.ToList());
        if (Data.ExploreQueue.Count > 0)
        {
            View.m_list_node.RefreshList(Data.ExploreQueue.Peek());
        }
        else
        {
            View.m_list_node.numItems = 0;
        }
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
        item.onClick.Set(() => OnClickNode(node));
    }

    public void OnClickNode(ExploreNode node)
    {
        node.OnSelected();
        GameMgr.Explore.Data.ExploreQueue.Dequeue();
        Refresh();
    }
}
