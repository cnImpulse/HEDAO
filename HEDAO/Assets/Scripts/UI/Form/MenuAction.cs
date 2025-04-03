using System;
using System.Collections.Generic;
using System.Linq;
using Cfg;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public enum RoleActionType
{
    None,
    [EnumName("术法")]
    Skill,
    [EnumName("遁术")]
    Move,
    [EnumName("调息")]
    Wait,
}

public class MenuAction : UIBase
{
    public new FGUIMenuAction View => base.View as FGUIMenuAction;
    public GridUnit BattleUnit => GameMgr.Battle.Data.BattleUnitQueue.Peek();

    private Fsm m_Fsm;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        
        InitFsm();
    }

    protected override void OnShow()
    {
        base.OnShow();

        m_Fsm.Start<ActionSelect>();
    }

    private void InitFsm()
    {
        m_Fsm = Fsm.CreatFsm(this,  new ActionSelect(), new ActionMove(), new ActionSkill(), new ActionWait());
    }
}
