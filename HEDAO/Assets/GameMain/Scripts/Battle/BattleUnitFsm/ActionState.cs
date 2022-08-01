using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public enum ActionType
    {
        Skill,
        Await,
    }

    public class ActionState : BattleUnitBaseState
    {
        protected override void OnEnter(IFsm<BattleUnit> fsm)
        {
            base.OnEnter(fsm);

            GameEntry.UI.OpenUIForm(UIFromName.ActionForm, this);
        }

        protected override void OnUpdate(IFsm<BattleUnit> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<BattleUnit> fsm, bool isShutdown)
        {
            GameEntry.UI.CloseUIForm(UIFromName.ActionForm);

            base.OnLeave(fsm, isShutdown);
        }

        public void SelectAction(ActionType actionType)
        {
            if (actionType == ActionType.Skill)
            {
                ChangeState<SkillState>();
            }
            else if (actionType == ActionType.Await)
            {
                ChangeState<EndActionState>();
            }
        }
    }
}