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

            GameEntry.Fsm.StartCoroutine(AutoAction(Owner));
        }

        protected override void OnUpdate(IFsm<BattleUnit> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<BattleUnit> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }

        public IEnumerator AutoAction(BattleUnit battleUnit)
        {
            yield return ShowMoveArea(battleUnit);

            BattleUnit attackTarget = AI.SelectAttackTarget();
            if (attackTarget == null)
            {
                ChangeState<EndActionState>();
                yield break;
            }

            GridData end = AI.SelectMoveTarget(attackTarget);
            bool result = Navigator.Navigate(GridMap.Data, Owner, end, out var path);
            if (result)
            {
                yield return battleUnit.Move(path, end);

                var canReleaseList = GridMap.Data.GetRangeGridList(Owner.Data.GridPos, 1);
                GameEntry.Effect.ShowGridEffect(GameEntry.Cfg.GridEffect.Streak, canReleaseList.ConvertAll((input) => input.GridPos), 0.5f, Color.red);
                yield return new WaitForSeconds(0.5f);
                GameEntry.Effect.HideGridEffect();

                yield return new WaitForSeconds(0.2f);
                AI.Attack(attackTarget);
                //GameEntry.Skill.RequestReleaseSkill(skillId, battleUnit.Id, attackTarget.Id);
            }

            ChangeState<EndActionState>();
        }

        public IEnumerator ShowMoveArea(BattleUnit battleUnit)
        {
            int effectId = GameEntry.Effect.ShowEffect(GameEntry.Cfg.Effect.Select, battleUnit.transform.position, true, 1.5f);
            yield return new WaitForSeconds(1.5f);

            var canMoveList = GridMap.Data.GetCanMoveGrids(battleUnit, battleUnit.Data.MOV);
            GameEntry.Effect.ShowGridEffect(GameEntry.Cfg.GridEffect.Streak, canMoveList.ConvertAll((input) => input.GridPos), 0.8f, Color.yellow);
            yield return new WaitForSeconds(0.8f);
        }
    }
}