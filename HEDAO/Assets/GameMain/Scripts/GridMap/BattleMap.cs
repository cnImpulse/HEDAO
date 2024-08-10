using System.Collections.Generic;
using FairyGUI;
using GameFramework.Event;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    /// <summary>
    /// 网格地图。
    /// </summary>
    public class BattleMap : GridMap
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowBattleUnitScuess);
            GameEntry.Event.Subscribe(EventName.BattleUnitDead, OnBattleUnitDead);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            GameEntry.Event.Unsubscribe(EventName.BattleUnitDead, OnBattleUnitDead);
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowBattleUnitScuess);

            base.OnHide(isShutdown, userData);
        }

        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);

        }

        protected override void OnDetached(EntityLogic childEntity, object userData)
        {

            base.OnDetached(childEntity, userData);
        }

        /// <summary>
        /// 注册战斗单位实体
        /// </summary>
        public bool RegisterBattleUnit(CharacterData data, Vector2Int gridPos, CampType campType)
        {
            BattleUnitData battleUnitData = new BattleUnitData(data, gridPos, campType);
            GameEntry.Entity.ShowBattleUnit(battleUnitData);
            return true;
        }

        public BattleUnit GetBattleUnit(int entityId)
        {
            if (m_GridUnitDic.TryGetValue(entityId, out var gridUnit))
            {
                return gridUnit as BattleUnit;
            }

            return null;
        }

        public List<BattleUnit> GetBattleUnitList(CampType campType = CampType.None)
        {
            List<BattleUnit> battleUnitList = new List<BattleUnit>();
            foreach (var gridUnit in m_GridUnitDic.Values)
            {
                var battleUnit = gridUnit as BattleUnit;
                if (campType == CampType.None || battleUnit.Data.CampType == campType)
                {
                    battleUnitList.Add(battleUnit);
                }
            }

            return battleUnitList;
        }

        public void SetGridUnitPos(GridUnit gridUnit, Vector2Int gridPos)
        {
            if (!m_GridUnitDic.ContainsKey(gridUnit.Id))
            {
                Log.Error("单位{0}不在地图中。", gridUnit.Id);
                return;
            }

            var end = m_Data.GetGridData(gridPos);
            if (end == null)
            {
                Log.Error("单元格{0}不存在。", gridPos);
                return;
            }
            
            if (end.GridUnit != null)
            {
                Log.Error("单元格已经被占据,无法进入!");
                return;
            }

            var start = gridUnit.GridData;
            start.OnGridUnitLeave();
            end.OnGridUnitEnter(gridUnit);
            
            gridUnit.Data.GridPos = gridPos;
            gridUnit.transform.position = GridPosToWorldPos(gridPos);
        }

        private void OnShowBattleUnitScuess(object sender, GameEventArgs e)
        {
            var ne = (ShowEntitySuccessEventArgs)e;

            var battleUnit = ne.Entity.Logic as BattleUnit;
            if (battleUnit == null)
            {
                return;
            }

            GameEntry.Entity.AttachEntity(battleUnit.Id, Id);
        }

        private void OnBattleUnitDead(object sender, GameEventArgs e)
        {
            var ne = (GameEventBase)e;
            var id = (VarInt32)ne.EventData;
            var battleUnit = GetBattleUnit(id);
            var battleEnd = GetBattleUnitList(battleUnit.Data.CampType).Count <= 1;
            var failCampType = battleUnit.Data.CampType;
            GameEntry.Entity.HideEntity(id);
            if (battleEnd)
            {
                GameEntry.Event.Fire(this, EventName.BattleEnd, failCampType);            
            }
        }
    }
}
