using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer : FsmState
{
    public GridUnit BattleUnit => GameMgr.Battle.Data.BattleUnitQueue.Peek();

    public override void OnEnter()
    {
        base.OnEnter();

        BattleUnit.OnRoundStart();
        GameMgr.Event.Fire(GameEventType.OnPlayerRoundStart);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }

    public override void OnLeave()
    {
        BattleUnit.OnRoundEnd();
        GameMgr.Battle.Data.BattleUnitQueue.Dequeue();
        
        base.OnLeave();
    }
}
