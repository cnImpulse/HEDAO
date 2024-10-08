using System;
using GameFramework.Fsm;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public abstract class BattleUnitStateBase : FsmState<BattleUnit>
    {
        public IFsm<BattleUnit> Fsm { get; private set; }
        public BattleUnit Owner => Fsm?.Owner;

        protected BattleMap BattleMap => Owner.BattleMap;

        private Type m_NextState = null;

        protected override void OnInit(IFsm<BattleUnit> fsm)
        {
            base.OnInit(fsm);

            Fsm = fsm;
        }

        protected override void OnEnter(IFsm<BattleUnit> fsm)
        {
            base.OnEnter(fsm);

            Log.Info("Enter {0}", GetType());
        }

        protected override void OnUpdate(IFsm<BattleUnit> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            if (m_NextState != null)
            {
                ChangeState(fsm, m_NextState);
            }
        }

        protected override void OnLeave(IFsm<BattleUnit> fsm, bool isShutdown)
        {
            m_NextState = null;

            base.OnLeave(fsm, isShutdown);
        }

        protected override void OnDestroy(IFsm<BattleUnit> fsm)
        {
            Fsm = null;

            base.OnDestroy(fsm);
        }

        /// <summary>
        /// 会在下一帧切换状态
        /// </summary>
        public void ChangeState<T>()
            where T : BattleUnitStateBase
        {
            m_NextState = typeof(T);
        }
    }
}