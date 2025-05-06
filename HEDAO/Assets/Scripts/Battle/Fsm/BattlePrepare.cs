using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlePrepare : BattleStateBase
{
    public override void OnEnter()
    {
        base.OnEnter();

        for (int i = 0; i < Data.PlayerTeam.Count; ++i)
        {
            var role = Data.PlayerTeam[i];
            var view = GameMgr.Entity.ShowEntity<BattleUnitView>(role);
            GameMgr.Battle.BattleMapView.AddBattleUnitView(view, i);
        }

        for (int i = 0; i < Data.EnemyTeam.Count; ++i)
        {
            var role = Data.EnemyTeam[i];
            var view = GameMgr.Entity.ShowEntity<BattleUnitView>(role);
            GameMgr.Battle.BattleMapView.AddBattleUnitView(view, i);
        }
    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
}
