using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class BattleState : BattleStateBase
    {
        protected override void OnInit(IFsm<ProcedureBattle> fsm)
        {
            base.OnInit(fsm);

            GameEntry.Event.Subscribe(EventName.PointerDownGridMap, OnPointGridMap);
        }

        protected override void OnEnter(IFsm<ProcedureBattle> fsm)
        {
            base.OnEnter(fsm);

            GameEntry.Event.Subscribe(EventName.BattleUnitActionCancel, OnBattleUnitActionCancel);
            GameEntry.Event.Subscribe(EventName.BattleUnitActionEnd, OnBattleUnitActionEnd);

            if (IsAutoBattle)
            {
                BattleUnitFsm.Start<AutoActionState>();
            }
            else
            {
                BattleUnitFsm.Start<MoveState>();
            }
        }

        protected override void OnUpdate(IFsm<ProcedureBattle> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<ProcedureBattle> fsm, bool isShutdown)
        {
            DestoryBattleUnitFsm();
            GameEntry.Event.Unsubscribe(EventName.BattleUnitActionCancel, OnBattleUnitActionCancel);
            GameEntry.Event.Unsubscribe(EventName.BattleUnitActionEnd, OnBattleUnitActionEnd);

            base.OnLeave(fsm, isShutdown);
        }

        private void DestoryBattleUnitFsm()
        {
            if (BattleUnitFsm == null)
            {
                return;
            }

            GameEntry.Fsm.DestroyFsm(BattleUnitFsm);
            BattleUnitFsm = null;
        }

        private void OnBattleUnitActionEnd(object sender, GameEventArgs e)
        {
            DestoryBattleUnitFsm();
            var battleUnitList = GridMap.GetBattleUnitList(ActiveCamp);
            foreach (var battleUnit in battleUnitList)
            {
                if (battleUnit.CanAction)
                {
                    ChangeState<BattleUnitSelectState>();
                    return;
                }
            }

            ChangeState<RoundEndState>();
        }

        private void OnBattleUnitActionCancel(object sender, GameEventArgs e)
        {
            DestoryBattleUnitFsm();
            ChangeState<BattleUnitSelectState>(Fsm);
        }

        private void OnPointGridMap(object sender, GameEventArgs e)
        {
            var ne = e as GameEventBase;
            var gridData = ne.EventData as GridData;
            var gridUnit = gridData.GridUnit;
            if (gridUnit == null)
            {
                return;
            }
        }
    }
}