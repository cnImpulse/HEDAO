using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateBase : FsmState
{
    public BattleData Data => GameMgr.Battle.Data;
    public Role CurBattleUnit => GameMgr.Battle.Data.BattleUnitQueue.Peek();

    public override void OnEnter()
    {
        base.OnEnter();

    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
}
