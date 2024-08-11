using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class RoundEndState : BattleStateBase
    {
        protected override void OnEnter(IFsm<ProcedureBattle> fsm)
        {
            base.OnEnter(fsm);

            var battleUnitList = BattleMap.GetBattleUnitList(ActiveCamp);
            foreach (var battleUnit in battleUnitList)
            {
                battleUnit.OnRoundEnd();
            }

            BattleData.ActiveCamp = BattleUtl.GetHostileCamp(BattleData.ActiveCamp);
        }

        protected override void OnUpdate(IFsm<ProcedureBattle> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            ChangeState<RoundStartState>(fsm);
        }

        protected override void OnLeave(IFsm<ProcedureBattle> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }
    }
}