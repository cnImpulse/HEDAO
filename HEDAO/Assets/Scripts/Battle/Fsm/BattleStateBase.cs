using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStateBase : FsmState
{
    public GridMap BattleMap => GameMgr.Battle.Data.GridMap;

    public override void OnEnter()
    {
        base.OnEnter();


    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
}
