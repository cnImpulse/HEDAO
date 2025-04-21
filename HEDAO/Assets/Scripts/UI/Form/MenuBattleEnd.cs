using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;
using Cfg;

public class MenuBattleEnd : UIBase
{
    public new FGUIMenuBattleEnd View => base.View as FGUIMenuBattleEnd;
    public BattleEndEvent BattleResult;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        BattleResult = userData as BattleEndEvent;

        View.m_btn_sure.onClick.Set(OnClickSure);
        View.m_txt_result.text = BattleResult.Result.GetName();
    }

    protected override void OnShow()
    {
        base.OnShow();

    }

    private void OnClickSure()
    {
        GameMgr.Battle.EndBattle();
    }
}
