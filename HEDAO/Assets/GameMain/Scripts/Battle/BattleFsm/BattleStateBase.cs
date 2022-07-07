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
        public ProcedureBattle Owner => Fsm == null ? null : Fsm.Owner;
        public BattleRunTimeData BattleData => Owner.BattleData;

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
        }

        protected override void OnLeave(IFsm<ProcedureBattle> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }

        protected override void OnDestroy(IFsm<ProcedureBattle> fsm)
        {
            Fsm = null;
            base.OnDestroy(fsm);
        }
    }
}