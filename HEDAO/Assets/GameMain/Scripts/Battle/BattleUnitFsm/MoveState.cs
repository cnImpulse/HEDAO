using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class MoveState : BattleUnitStateBase
    {
        private int m_EffectId = 0;
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

            if (m_CanMoveList != null)
            {
                var gridPos = GridMap.WorldPosToGridPos(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (m_CanMoveList.Contains(GridMap.Data.GetGridData(gridPos)))
                {
                    var position = GridMap.GridPosToWorldPos(gridPos);
                    if (m_EffectId > 0)
                    {
                        GameEntry.Effect.SetEffectPos(m_EffectId, position);
                    }
                    else
                    {
                        m_EffectId = GameEntry.Effect.ShowEffect(GameEntry.Cfg.Effect.Select, position, true);
                    }
                }
                else
                {
                    GameEntry.Effect.HideEffect(m_EffectId);
                    m_EffectId = 0;
                }
            }
        }

        protected override void OnLeave(IFsm<BattleUnit> fsm, bool isShutdown)
        {
            m_CanMoveList = null;
            GameEntry.Effect.HideGridEffect();
            GameEntry.Effect.HideEffect(m_EffectId);
            m_EffectId = 0;
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
                ChangeState<SelectActionState>();
            }
            else if (m_CanMoveList.Contains(gridData))
            {
                Owner.Move(gridData);
                ChangeState<SelectActionState>();
            }
            else
            {
                //GameEntry.Event.Fire(this, EventName.BattleUnitActionCancel);
            }
        }
    }
}