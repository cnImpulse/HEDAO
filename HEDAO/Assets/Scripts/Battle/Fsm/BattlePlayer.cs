using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePlayer : FsmState
{
    public override void OnEnter(object data)
    {
        base.OnEnter(data);

        GameMgr.Event.Subscribe(GameEventType.OnPointerDownMap, OnPointerDownMap);
    }

    public override void OnLeave()
    {
        GameMgr.Event.Unsubscribe(GameEventType.OnPointerDownMap, OnPointerDownMap);

        base.OnLeave();
    }

    private void OnPointerDownMap(GameEvent e)
    {
        var gridPos = (Vector2Int)e.Data;
        GameMgr.Effect.ShowEffect(10003, GameMgr.Battle.GridMapView.GridPosToWorldPos(gridPos));
    }
}
