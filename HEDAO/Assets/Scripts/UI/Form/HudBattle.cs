using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class HudBattle : UIBase
{
    public new FGUIHudBattle View => base.View as FGUIHudBattle;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        View.m_btn_start.onClick.Set(OnClickStart);
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
    }
    
    private void OnClickStart()
    {
        GameMgr.Battle.Fsm.ChangeState<BattleStart>();
    }
}
