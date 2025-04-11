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

        BattleUnit.InitAI();
        BattleUnit.OnRoundStart();

        GameMgr.Battle.GridMapView.StartCoroutine(AutoAction(BattleUnit));
    }

    public override void OnLeave()
    {
        GameMgr.Effect.HideGridEffect();
        BattleUnit.OnRoundEnd();

        base.OnLeave();
    }

    public IEnumerator AutoAction(GridUnit battleUnit)
    {
        yield return ShowMoveArea(battleUnit);

        GridUnit attackTarget = AI.SelectAttackTarget();
        if (attackTarget == null)
        {
            ChangeState<BattleLoop>();
            yield break;
        }

        GridData end = AI.SelectMoveTarget(attackTarget);
        bool result = Navigator.Navigate(BattleMap, BattleUnit, end, out var path);
        if (result)
        {
            yield return BattleUnit.Move(path, end);

            var canReleaseList = BattleMap.GetRangeGridList(BattleUnit.GridPos, AI.MaxATKRange);
            GameMgr.Effect.ShowGridEffect(canReleaseList.Select((grid) => { return grid.GridPos; }).ToList(), Color.red, 0.5f);
            yield return new WaitForSeconds(0.7f);

            AI.Attack(attackTarget);
        }

        ChangeState<BattleLoop>();
    }

    public IEnumerator ShowMoveArea(GridUnit battleUnit)
    {
        GameMgr.Effect.ShowEffect(10003, GridMapUtl.GridPos2WorldPos(battleUnit.GridPos), true, 1.5f);
        yield return new WaitForSeconds(1.5f);

        var canMoveList = BattleMap.GetCanMoveGrids(battleUnit, battleUnit.MOV);
        GameMgr.Effect.ShowGridEffect(canMoveList.Select((grid) => { return grid.GridPos; }).ToList(), Color.red, 0.8f);
        yield return new WaitForSeconds(0.8f);
    }
}
