using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class ActionStateBase : BattleUnitStateBase
    {
        protected string m_ActionFormName = "";

        protected override void OnInit(IFsm<BattleUnit> fsm)
        {
            base.OnInit(fsm);
        }

        protected override void OnEnter(IFsm<BattleUnit> fsm)
        {
            base.OnEnter(fsm);

            GameEntry.UI.OpenUIForm(m_ActionFormName, this);
        }

        protected override void OnUpdate(IFsm<BattleUnit> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<BattleUnit> fsm, bool isShutdown)
        {
            GameEntry.UI.CloseUIForm(m_ActionFormName);

            base.OnLeave(fsm, isShutdown);
        }

        public void CancelAction()
        {
            ChangeState<SelectActionState>();
        }
    }
}