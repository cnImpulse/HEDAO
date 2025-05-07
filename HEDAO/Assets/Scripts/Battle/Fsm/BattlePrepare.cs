using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePrepare : BattleStateBase
{
    public override void OnEnter()
    {
        base.OnEnter();

        foreach(var role in Data.BattleUnitDict.Values)
        {
            var view = GameMgr.Entity.ShowEntity<BattleUnitView>(role);
            GameMgr.Battle.BattleMapView.AddBattleUnitView(view);
        }

        GameMgr.Battle.Fsm.ChangeState<BattleStart>();
    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
}
