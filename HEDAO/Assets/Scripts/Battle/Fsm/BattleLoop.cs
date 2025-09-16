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
        if (battleUnit is PlayerRole)
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
            var list = Data.BattleUnitDict.Values.ToList();
            var speedDict = new Dictionary<Role, int>();
            foreach (var unit in list)
            {
                speedDict[unit] = unit.Attr.SPD + Random.Range(1, 4);
            }
            
            list.Sort((a, b) => speedDict[b].CompareTo(speedDict[a]));
            foreach (var battleUnit in list)
            {
                Data.BattleUnitQueue.Enqueue(battleUnit);
            }
        }
    }
}
