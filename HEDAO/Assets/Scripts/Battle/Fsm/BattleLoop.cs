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

        RefreshQueue();
        var battleUnit = Data.BattleUnitQueue.Peek();

        var view = GameMgr.Entity.GetEntityView<GridUnitView>(battleUnit.Id);
        GameMgr.Camera.VirtualCamera.Follow = view.transform;
        if (battleUnit.CampType == ECampType.Player)
        {
            GameMgr.Battle.Fsm.ChangeState<BattlePlayer>();
        }
        else
        {
            GameMgr.Battle.Fsm.ChangeState<BattleAI>();
        }
    }

    public override void OnLeave()
    {

        base.OnLeave();
    }

    public void RefreshQueue()
    {
        if (Data.BattleUnitQueue.Count == 0)
        {
            var list = Data.GridMap.GridUnitDict.Values.ToList();
            list.Sort((a, b) => b.SPD.CompareTo(a.SPD));
            foreach(var gridUnit in list)
            {
                Data.BattleUnitQueue.Enqueue(gridUnit);
            }
        }
    }
}
