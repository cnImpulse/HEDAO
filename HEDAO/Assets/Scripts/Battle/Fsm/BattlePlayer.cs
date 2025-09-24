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
        GameMgr.Event.Fire(GameEventType.OnPlayerRoundStart);
        
        GameMgr.Effect.ShowEffect(new EffectData() { PrefabId = 10006, FollowId = CurBattleUnit.Id });
        var view = GameMgr.Entity.GetEntityView<BattleUnitView>(CurBattleUnit.Id);
        view.PlayAnim("selected");

        bool action = CurBattleUnit.Battle.RoundStart();
        if (!action)
        {
            GameMgr.Event.Fire(GameEventType.OnBattleUnitActionEnd);
        }
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

    }

    public override void OnLeave()
    {
        GameMgr.Effect.HideEffectByPrefabId(10006);
        Data.BattleUnitQueue.Dequeue();

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
