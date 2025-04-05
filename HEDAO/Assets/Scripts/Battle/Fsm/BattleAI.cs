using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAI : FsmState
{
    public GridUnit BattleUnit => GameMgr.Battle.Data.BattleUnitQueue.Peek();

    public override void OnEnter()
    {
        base.OnEnter();

        BattleUnit.OnRoundStart();
    }

    public override void OnLeave()
    {

        base.OnLeave();
    }

    public void AutoMove()
    {

    }

    public void AutoPlaySkill()
    {

    }
}
