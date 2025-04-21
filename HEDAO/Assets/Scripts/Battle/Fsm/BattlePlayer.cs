using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer : BattleStateBase
{
    public GridUnit BattleUnit => GameMgr.Battle.Data.BattleUnitQueue.Peek();

    public override void OnEnter()
    {
        base.OnEnter();

        GameMgr.Event.Subscribe(GameEventType.OnBattleUnitActionEnd, OnPlayerRoundEnd);
        
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
        GameMgr.Event.Unsubscribe(GameEventType.OnBattleUnitActionEnd, OnPlayerRoundEnd);
        
        base.OnLeave();
    }
    
    private void OnPlayerRoundEnd(GameEvent obj)
    {
        if (Data.BattleResult == EResult.None)
        {
            ChangeState<BattleLoop>();
        }
        else
        {
            ChangeState<BattleEnd>();
        }
    }
}
