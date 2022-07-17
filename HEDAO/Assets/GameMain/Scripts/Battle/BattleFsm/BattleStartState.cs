using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Fsm;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class BattleStartState : BattleStateBase
    {
        private bool m_StartBattle = false;
        private BattleUnit m_CurSelectedUnit = null;

        protected override void OnEnter(IFsm<ProcedureBattle> fsm)
        {
            base.OnEnter(fsm);

            GameEntry.Event.Subscribe(EventName.PointerDownGridMap, OnPointGridMap);
            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowGirdMapSuccess);

            InitGridMap();
            GameEntry.UI.OpenUIForm(UIFromName.BattleForm, this);
        }

        protected override void OnUpdate(IFsm<ProcedureBattle> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            if (m_StartBattle)
            {
                var battleUnitList = BattleData.GridMap.GetBattleUnitList();
                foreach (var battleUnit in battleUnitList)
                {
                    battleUnit.OnBattleStart();
                }
                ChangeState<RoundStartState>(fsm);
            }
        }

        protected override void OnLeave(IFsm<ProcedureBattle> fsm, bool isShutdown)
        {
            m_StartBattle = false;
            GameEntry.Effect.HideGridEffect();
            GameEntry.Effect.HideEffect(GameEntry.Cfg.Effect.Select);

            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowGirdMapSuccess);
            GameEntry.Event.Unsubscribe(EventName.PointerDownGridMap, OnPointGridMap);

            base.OnLeave(fsm, isShutdown);
        }

        public void StartBattle()
        {
            m_StartBattle = true;
        }

        private void InitGridMap()
        {
            GameEntry.Entity.ShowGridMap(BattleData.LevelData.MapId);
        }

        private void ShowPlayerBrith()
        {
            List<Vector2Int> playerBrith = BattleData.LevelData.PlayerBrithList.ConvertAll((input) => BattleData.GridMap.Data.GetGridData(input).GridPos);
            GameEntry.Effect.ShowGridEffect(GameEntry.Cfg.GridEffect.Brith, playerBrith);
        }

        private void InitBattleUnit()
        {
            var gridMap = BattleData.GridMap;

            // 初始化敌方单位
            foreach (var pair in BattleData.LevelData.EnemyDic)
            {
                var gridData = gridMap.Data.GetGridData(pair.Key);
                if (gridData == null)
                {
                    continue;
                }
                
                gridMap.RegisterBattleUnit(new RoleData(pair.Value), gridData.GridPos, CampType.Enemy);
            }

            // 初始化己方单位
            Queue<int> roleQueue = new(GameEntry.Save.SaveData.RoleList);
            foreach (var gridIndex in BattleData.LevelData.PlayerBrithList)
            {
                if (roleQueue.Count == 0)
                {
                    break;
                }

                var gridData = gridMap.Data.GetGridData(gridIndex);
                if (gridData == null)
                {
                    continue;
                }

                gridMap.RegisterBattleUnit(new RoleData(roleQueue.Dequeue()), gridData.GridPos, CampType.Player);
            }
        }

        private void OnShowGirdMapSuccess(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;
            if (ne.Entity.Logic is GridMap)
            {
                BattleData.GridMap = ne.Entity.Logic as GridMap;
                ShowPlayerBrith();
                InitBattleUnit();
            }
        }

        private void OnPointGridMap(object sender, GameEventArgs e)
        {
            var ne = e as GameEventBase;
            var gridData = ne.EventData as GridData;

            GameEntry.Effect.HideEffect(GameEntry.Cfg.Effect.Select);
            if (!BattleData.LevelData.PlayerBrithList.Contains(gridData.GridIndex))
            {
                m_CurSelectedUnit = null;
                return;
            }

            var gridMap = BattleData.GridMap;
            if (m_CurSelectedUnit == null)
            {
                var battleUnit = gridMap.GetBattleUnit(gridData.GridPos);
                if (battleUnit == null || battleUnit.Data.CampType != CampType.Player)
                {
                    return;
                }
                m_CurSelectedUnit = battleUnit;
                GameEntry.Effect.ShowEffect(GameEntry.Cfg.Effect.Select, gridMap.GridPosToWorldPos(gridData.GridPos), true);
            }
            else
            {
                gridMap.SetGridUnitPos(m_CurSelectedUnit, gridData.GridPos);
                m_CurSelectedUnit = null;
            }
        }
    }
}