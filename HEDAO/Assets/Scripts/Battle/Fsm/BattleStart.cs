using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStart : FsmState
{
    public override void OnEnter()
    {
        base.OnEnter();

        GameMgr.Battle.Fsm.ChangeState<BattleLoop>();
    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
}
