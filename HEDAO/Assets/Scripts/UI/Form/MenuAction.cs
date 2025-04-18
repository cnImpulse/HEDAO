using System;
using System.Collections.Generic;
using System.Linq;
using Cfg;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class MenuAction : UIBase
{
    public new FGUIMenuAction View => base.View as FGUIMenuAction;
    public GridUnit BattleUnit => GameMgr.Battle.Data.BattleUnitQueue.Peek();
    public ReqBattleUnitAction Req;

    private Fsm m_Fsm;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        
        InitFsm();
    }

    protected override void OnShow()
    {
        base.OnShow();

        m_Fsm.Start<ActionMove>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        m_Fsm.OnUpdate();
    }

    protected override void OnClose()
    {
        Fsm.DestroyFsm(m_Fsm);

        base.OnClose();
    }

    private void InitFsm()
    {
        Req = new ReqBattleUnitAction { Caster = BattleUnit };
        m_Fsm = Fsm.CreatFsm(this,  new ActionSelect(), new ActionMove(), new ActionSkill(), new ActionWait());
    }
}
