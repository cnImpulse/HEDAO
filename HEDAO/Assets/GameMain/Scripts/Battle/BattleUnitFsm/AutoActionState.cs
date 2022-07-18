using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;

namespace HEDAO
{
    public class AutoActionState : BattleUnitBaseState
    {
        private CommonAI AI => Owner.AI;

        protected override void OnEnter(IFsm<BattleUnit> fsm)
        {
            base.OnEnter(fsm);

            BattleUnit attackTarget = AI.SelectAttackTarget();
            GridData end = AI.SelectMoveTarget(attackTarget);

            bool result = Navigator.Navigate(m_GridMap.Data, Owner, end, out var path);
            if (result == true)
            {
                GameEntry.Fsm.StartCoroutine(AutoAction(Owner, attackTarget, path));
            }
            else
            {
                GameEntry.Fsm.StartCoroutine(AutoAction(Owner));
            }
        }

    protected override void OnUpdate(IFsm<BattleUnit> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<BattleUnit> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }

        public IEnumerator ShowMoveArea(BattleUnit battleUnit)
        {
            int effectId = GameEntry.Effect.ShowEffect(GameEntry.Cfg.Effect.Select, battleUnit.transform.position);
            yield return new WaitForSeconds(1.5f);
            GameEntry.Effect.HideEffect(effectId);

            var canMoveList = m_GridMap.Data.GetCanMoveGrids(battleUnit, battleUnit.Data.MOV);
            GameEntry.Effect.ShowGridEffect(GameEntry.Cfg.GridEffect.Brith, canMoveList.ConvertAll((input) => input.GridPos));
            yield return new WaitForSeconds(0.8f);
            GameEntry.Effect.HideGridEffect();
        }

        public IEnumerator AutoAction(BattleUnit battleUnit)
        {
            yield return ShowMoveArea(battleUnit);

            ChangeState<EndActionState>();
        }

        public IEnumerator AutoAction(BattleUnit battleUnit, BattleUnit attackTarget, List<GridData> path)
        {
            yield return ShowMoveArea(battleUnit);

            foreach (var gridData in path)
            {
                battleUnit.transform.position = m_GridMap.GridPosToWorldPos(gridData.GridPos);
                yield return new WaitForSeconds(0.3f);
            }
            if (path.Count >= 1)
            {
                Owner.Move(path[path.Count - 1]);
            }

            var canReleaseList = m_GridMap.Data.GetRangeGridList(Owner.Data.GridPos, 10);
            GameEntry.Effect.ShowGridEffect(GameEntry.Cfg.GridEffect.Brith, canReleaseList.ConvertAll((input) => input.GridPos));
            yield return new WaitForSeconds(0.5f);
            GameEntry.Effect.HideGridEffect();

            yield return new WaitForSeconds(0.2f);
            AI.Attack(attackTarget);
            //GameEntry.Skill.RequestReleaseSkill(skillId, battleUnit.Id, attackTarget.Id);

            ChangeState<EndActionState>();
        }
    }
}