using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnd : FsmState
{
    public override void OnEnter()
    {
        base.OnEnter();

        GameMgr.Event.Fire(GameEventType.BattleEvent, new BattleEndEvent { Result = GameMgr.Battle.Data.BattleResult });
    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
}
