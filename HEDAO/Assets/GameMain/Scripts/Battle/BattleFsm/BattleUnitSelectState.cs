using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class BattleUnitSelectState : BattleStateBase
    {
        protected override void OnEnter(IFsm<ProcedureBattle> fsm)
        {
            base.OnEnter(fsm);

            GameEntry.Event.Subscribe(EventName.PointerDownGridMap, OnPointGridMap);
        }

        protected override void OnUpdate(IFsm<ProcedureBattle> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            if (IsAutoBattle)
            {
                var battleUnitList = GridMap.GetBattleUnitList(ActiveCamp);
                foreach (var battleUnit in battleUnitList)
                {
                    if (CreatBattleUnitFsm(battleUnit))
                    {
                        break;
                    }
                }
            }

            if (BattleUnitFsm != null)
            {
                ChangeState<BattleState>(fsm);
            }
        }

        protected override void OnLeave(IFsm<ProcedureBattle> fsm, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(EventName.PointerDownGridMap, OnPointGridMap);

            base.OnLeave(fsm, isShutdown);
        }

        private bool CreatBattleUnitFsm(BattleUnit battleUnit)
        {
            if (!battleUnit.CanAction)
            {
                return false;
            }

            if (IsAutoBattle)
            {
                BattleData.BattleUnitFsm = GameEntry.Fsm.CreateFsm(battleUnit, new AutoActionState(), new EndActionState());
            }
            else
            {
                //m_BattleUnitFsm = GameEntry.Fsm.CreateFsm(battleUnit, new MoveState(),
                //    new ActionState(), new SkillState(), new EndActionState());
            }
            
            return true;
        }

        private void OnPointGridMap(object sender, GameEventArgs e)
        {
            var ne = e as GameEventBase;
            var gridData = ne.EventData as GridData;

            var battleUnit = GridMap.GetBattleUnit(gridData.GridPos);
            if (battleUnit == null)
            {
                return;
            }

            CreatBattleUnitFsm(battleUnit);
        }
    }
}