using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using FGUI.Common;
using System.Linq;

public class HudBattle : UIBase
{
    public new FGUIHudBattle View => base.View as FGUIHudBattle;
    public BattleUnitView CurBattleUnit;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        GameMgr.Event.Subscribe(GameEventType.OnPlayerRoundStart, OnSelectBattleUnit);

        View.m_list_action.itemRenderer = OnRenderRole;
    }

    protected override void OnShow()
    {
        base.OnShow();

        RefreshRolePanel();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        var state = GameMgr.Battle.Fsm.CurState;
        View.m_txt_battle_state.text = state.ToString();
        RefreshActionList();
    }

    protected override void OnClose()
    {
        GameMgr.Event.Unsubscribe(GameEventType.OnPlayerRoundStart, OnSelectBattleUnit);

        base.OnClose();
    }

    public void RefreshActionList()
    {
        //View.m_list_action.RefreshList(GameMgr.Battle.Data.BattleUnitQueue.ToList());
    }

    private void OnRenderRole(int index, GObject item, object data)
    {
        //var role = (data as GridUnit).Role;
        //var btn = item as FGUIBtnRole;
        //btn.mode = ButtonMode.Common;
        //btn.Refresh(role);
    }
    
    private void OnSelectBattleUnit(GameEvent obj)
    {
        //GameMgr.UI.ShowUI(UIName.MenuAction);
    }

    private void RefreshRolePanel()
    {
        var btn = View.m_comp_skill.m_btn_role as FGUIBtnRole;
        //btn.Refresh(CurBattleUnit.Entity);
    }
}
