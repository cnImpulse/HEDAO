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
        protected override void OnEnter(IFsm<ProcedureBattle> fsm)
        {
            base.OnEnter(fsm);

            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowGirdMapSuccess);

            InitGridMap();

            //var battleUnitList = m_GridMap.GetGridUnitList<BattleUnit>();
            //foreach (var battleUnit in battleUnitList)
            //{
            //    battleUnit.OnBattleStart();
            //}
        }

        protected override void OnUpdate(IFsm<ProcedureBattle> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            if (BattleData.GridMap)
            {
                ChangeState<RoundStartState>(fsm);
            }
        }

        protected override void OnLeave(IFsm<ProcedureBattle> fsm, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowGirdMapSuccess);

            base.OnLeave(fsm, isShutdown);
        }

        private void InitGridMap()
        {
            GameEntry.Entity.ShowGridMap(BattleData.LevelData.MapId);
        }

        private void ShowPlayerBrith()
        {
            List<Vector2Int> playerBrith = BattleData.LevelData.PlayerBrithList.ConvertAll((input) => BattleData.GridMap.Data.GetGridData(input).GridPos);
            GameEntry.Effect.ShowGridEffect(GameEntry.Cfg.Tables.TblGridEffect.Brith, playerBrith);
        }

        private void InitBattleUnit()
        {
            var gridMap = BattleData.GridMap;
            foreach (var pair in BattleData.LevelData.EnemyDic)
            {
                var gridData = gridMap.Data.GetGridData(pair.Key);
                if (gridData == null)
                {
                    continue;
                }
                
                gridMap.RegisterBattleUnit(new RoleData(pair.Value), gridData.GridPos, CampType.Enemy);
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
    }
}