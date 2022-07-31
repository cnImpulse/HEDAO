using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class ActionState : BattleUnitBaseState
    {
        protected override void OnEnter(IFsm<BattleUnit> fsm)
        {
            base.OnEnter(fsm);
        }

        protected override void OnUpdate(IFsm<BattleUnit> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<BattleUnit> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }

        //public void SelectAction(ActionType actionType)
        //{
        //    if (actionType == ActionType.Skill)
        //    {
        //        ChangeState<SkillState>();
        //    }
        //    else if (actionType == ActionType.Await)
        //    {
        //        ChangeState<EndActionState>();
        //    }
        //}
    }
}