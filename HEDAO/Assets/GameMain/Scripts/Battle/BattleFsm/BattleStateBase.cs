using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;
using System;

namespace HEDAO
{
    public abstract class BattleStateBase : FsmState<ProcedureBattle>
    {
        public IFsm<ProcedureBattle> Fsm { get; private set; }
        public ProcedureBattle Owner => Fsm?.Owner;
        public BattleRunTimeData BattleData => Owner.BattleData;

        public bool IsAutoBattle => true;//BattleData.ActiveCamp != CampType.Player;
        public GridMap GridMap => BattleData.GridMap;
        public CampType ActiveCamp => BattleData.ActiveCamp;
        public IFsm<BattleUnit> BattleUnitFsm { get => BattleData.BattleUnitFsm; set => BattleData.BattleUnitFsm = value; }

        private Type m_NextState = null;

        protected override void OnInit(IFsm<ProcedureBattle> fsm)
        {
            base.OnInit(fsm);
            Fsm = fsm;
        }

        protected override void OnEnter(IFsm<ProcedureBattle> fsm)
        {
            base.OnEnter(fsm);

            Log.Info("Enter {0}", GetType());
        }

        protected override void OnUpdate(IFsm<ProcedureBattle> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            if (m_NextState != null)
            {
                ChangeState(fsm, m_NextState);
            }
        }

        protected override void OnLeave(IFsm<ProcedureBattle> fsm, bool isShutdown)
        {
            Log.Info("Leave {0}", GetType());
            m_NextState = null;

            base.OnLeave(fsm, isShutdown);
        }

        protected override void OnDestroy(IFsm<ProcedureBattle> fsm)
        {
            Fsm = null;
            base.OnDestroy(fsm);
        }

        /// <summary>
        /// 会在下一帧切换状态
        /// </summary>
        public void ChangeState<T>()
            where T : BattleStateBase
        {
            m_NextState = typeof(T);
        }
    }
}