using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateBase : FsmState
{
    public BattleData Data => GameMgr.Battle.Data;
    public GridMap BattleMap => Data.GridMap;

    public override void OnEnter()
    {
        base.OnEnter();


    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
}
