using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class MenuMain : UIBase
{
    public new FGUIMenuMain View;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        //View.m_btn_start.onClick.Add(() => { GameMgr.UI.OpenUI(UIName.); });
        //View.m_btn_exit.onClick.Add(() => { Log.Info("退出游戏。"); });

        View.m_btn_battle.onClick.Add(() =>
        {
            
        });
    }

    protected override void OnShow()
    {
        base.OnShow();

    }
}
