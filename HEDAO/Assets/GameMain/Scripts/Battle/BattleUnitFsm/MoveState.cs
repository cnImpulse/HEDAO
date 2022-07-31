using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class MoveState : BattleUnitBaseState
    {
        private List<GridData> m_CanMoveList = null;

        protected override void OnEnter(IFsm<BattleUnit> fsm)
        {
            base.OnEnter(fsm);

            GameEntry.Event.Subscribe(EventName.PointerDownGridMap, OnPointGridMap);

            m_CanMoveList = GridMap.Data.GetCanMoveGrids(Owner);
            GameEntry.Effect.ShowMoveAreaEffect(m_CanMoveList);
        }

        protected override void OnUpdate(IFsm<BattleUnit> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
        }

        protected override void OnLeave(IFsm<BattleUnit> fsm, bool isShutdown)
        {
            m_CanMoveList = null;
            GameEntry.Effect.HideGridEffect();
            GameEntry.Event.Unsubscribe(EventName.PointerDownGridMap, OnPointGridMap);

            base.OnLeave(fsm, isShutdown);
        }

        private void OnPointGridMap(object sender, GameEventArgs e)
        {
            var ne = e as GameEventBase;
            var gridData = ne.EventData as GridData;
            var gridUnit = gridData.GridUnit;
            if (gridUnit == Owner)
            {
                ChangeState<ActionState>();
            }
            else if (m_CanMoveList.Contains(gridData))
            {
                Owner.Move(gridData);
                ChangeState<ActionState>();
            }
            else
            {
                //GameEntry.Event.Fire(this, EventName.BattleUnitActionCancel);
            }
        }
    }
}