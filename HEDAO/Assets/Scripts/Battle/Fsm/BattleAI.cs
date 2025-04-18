using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleAI : BattleStateBase
{
    public GridUnit BattleUnit => GameMgr.Battle.Data.BattleUnitQueue.Peek();
    public CommonAI AI => BattleUnit.AI;

    public override void OnEnter()
    {
        base.OnEnter();

        GameMgr.Event.Subscribe(GameEventType.OnBattleUnitActionEnd, OnPlayerRoundEnd);
        
        BattleUnit.InitAI();
        BattleUnit.OnRoundStart();

        var req = AI.AutoAction();
        GameMgr.Battle.ReqBattleUnitAction(req);
    }

    public override void OnLeave()
    {
        BattleUnit.OnRoundEnd();
        GameMgr.Event.Unsubscribe(GameEventType.OnBattleUnitActionEnd, OnPlayerRoundEnd);

        base.OnLeave();
    }

    public IEnumerator ShowMoveArea(GridUnit battleUnit)
    {
        // GameMgr.Effect.ShowEffect(10003, GridMapUtl.GridPos2WorldPos(battleUnit.GridPos), true, 1.5f);
        yield return new WaitForSeconds(1.5f);

        var canMoveList = BattleMap.GetCanMoveGrids(battleUnit, battleUnit.MOV);
        GameMgr.Effect.ShowGridEffect(canMoveList.Select((grid) => { return grid.GridPos; }).ToList(), Color.red, 0.8f);
        yield return new WaitForSeconds(0.8f);
    }
    
    private void OnPlayerRoundEnd(GameEvent obj)
    {
        ChangeState<BattleLoop>();
    }
}
