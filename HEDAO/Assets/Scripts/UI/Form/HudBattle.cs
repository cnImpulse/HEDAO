using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;
using System.Linq;

public class HudBattle : UIBase
{
    public new FGUIHudBattle View => base.View as FGUIHudBattle;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        View.m_btn_start.onClick.Set(OnClickStart);
        View.m_list_action.itemRenderer = OnRenderRole;
    }

    protected override void OnShow()
    {
        base.OnShow();

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        var state = GameMgr.Battle.Fsm.CurState;
        View.m_btn_start.visible = state.GetType() == typeof(BattlePrepare);
        View.m_txt_battle_state.text = state.ToString();

        RefreshActionList();
    }

    public void RefreshActionList()
    {
        View.m_list_action.RefreshList(GameMgr.Battle.Data.BattleUnitQueue.ToList());
    }

    private void OnRenderRole(int index, GObject item, object data)
    {
        var role = (data as GridUnit).Role;
        var btn = item as FGUIBtnRole;
        btn.mode = ButtonMode.Common;
        btn.Refresh(role);
    }

    private void OnClickStart()
    {
        GameMgr.Battle.Fsm.ChangeState<BattleStart>();
    }
}
