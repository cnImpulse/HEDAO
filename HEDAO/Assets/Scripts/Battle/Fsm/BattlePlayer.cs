using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer : BattleStateBase
{
    public override void OnEnter()
    {
        base.OnEnter();

        GameMgr.Event.Subscribe(GameEventType.OnBattleUnitActionEnd, OnPlayerRoundEnd);

        GameMgr.Effect.ShowEffect(new EffectData() { PrefabId = 10006, FollowId = CurBattleUnit.Id });
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }

    public override void OnLeave()
    {
        GameMgr.Effect.HideEffectByPrefabId(10006);

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
