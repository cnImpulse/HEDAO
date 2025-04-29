using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleLoop : FsmState
{
    public BattleData Data => GameMgr.Battle.Data;

    public override void OnEnter()
    {
        base.OnEnter();

    }

    public override void OnLeave()
    {

        base.OnLeave();
    }

    public void RefreshQueue()
    {

    }
}
