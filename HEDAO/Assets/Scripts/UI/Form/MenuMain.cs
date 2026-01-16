using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class MenuMain : UIBase
{
    public new FGUIMenuMain View => base.View as FGUIMenuMain;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        View.m_btn_start.onClick.Add(() =>
        {
            GameMgr.UI.ShowUI(UIName.WinLoadGame);
        });

        View.m_btn_battle.onClick.Add(() =>
        {
            // GameMgr.Save.LoadTestBattleData();
            // GameMgr.Procedure.Fsm.ChangeState<ProcedureBattle>();
            
            GameMgr.Save.LoadTestExporeData();
            GameMgr.Procedure.Fsm.ChangeState<ProcedureExplore>();
        });
        
        //View.m_btn_exit.onClick.Add(() => { Log.Info("退出游戏。"); });
    }

    protected override void OnShow()
    {
        base.OnShow();

    }
}
