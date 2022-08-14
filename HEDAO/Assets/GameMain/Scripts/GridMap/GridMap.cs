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
    public class GridMap : Entity, IPointerDownHandler
    {
        private Tilemap[] m_TilemapList = null;

        private GridMapData m_Data = null;

        public new GridMapData Data => m_Data;

        private Dictionary<Vector2Int, GridUnit> m_GridUnitDic = default;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_GridUnitDic = new Dictionary<Vector2Int, GridUnit>();
            m_TilemapList = GetComponentsInChildren<Tilemap>();
            m_TilemapList[0].gameObject.GetOrAddComponent<BoxCollider2D>();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, OnShowBattleUnitScuess);

            m_Data = userData as GridMapData;
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, OnShowBattleUnitScuess);

            base.OnHide(isShutdown, userData);
        }

        /// <summary>
        /// 网格坐标转世界坐标
        /// </summary>
        public Vector3 GridPosToWorldPos(Vector2Int gridPos)
        {
            return m_TilemapList[0].GetCellCenterWorld((Vector3Int)gridPos);
        }

        /// <summary>
        /// 世界坐标转网格坐标
        /// </summary>
        public Vector2Int WorldPosToGridPos(Vector3 worldPosition)
        {
            return (Vector2Int)m_TilemapList[0].WorldToCell(worldPosition);
        }

        /// <summary>
        /// 注册战斗单位实体
        /// </summary>
        public bool RegisterBattleUnit(RoleData roleData, Vector2Int gridPos, CampType campType)
        {
            BattleUnitData battleUnitData = new BattleUnitData(roleData, gridPos, campType);
            //if (gridData == null || !gridData.CanArrive())
            //{
            //    Log.Warning("注册战斗单位失败!");
            //    return false;
            //}

            GameEntry.Entity.ShowBattleUnit(battleUnitData);
            return true;
        }

        /// <summary>
        /// 注销网格单位实体
        /// </summary>
        public bool UnRegisterGridUnit(GridUnit gridUnit)
        {
            if (gridUnit == null)
            {
                Log.Warning("注销网格单位失败!");
                return false;
            }

            m_GridUnitDic.Remove(gridUnit.Data.GridPos);
            gridUnit.GridData.OnGridUnitLeave();
            GameEntry.Entity.HideEntity(gridUnit);
            return true;
        }

        public BattleUnit GetBattleUnit(Vector2Int gridPos)
        {
            if (m_GridUnitDic.TryGetValue(gridPos, out var gridUnit))
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
            if (m_GridUnitDic.ContainsKey(gridPos))
            {
                Log.Error("单元格{0}被占据。", gridPos);
                return;
            }

            var gridData = m_Data.GetGridData(gridPos);
            if (gridData == null)
            {
                Log.Error("单元格{0}不存在。", gridPos);
            }

            m_GridUnitDic.Remove(gridUnit.Data.GridPos);
            m_GridUnitDic.Add(gridPos, gridUnit);
            gridUnit.Data.GridPos = gridPos;
            gridUnit.transform.position = GridPosToWorldPos(gridPos);
        }

        public void OnShowBattleUnitScuess(object sender, GameEventArgs e)
        {
            var ne = (ShowEntitySuccessEventArgs)e;

            var battleUnit = ne.Entity.Logic as BattleUnit;
            if (battleUnit == null)
            {
                return;
            }

            m_GridUnitDic.Add(battleUnit.Data.GridPos, battleUnit);
            GameEntry.Entity.AttachEntity(battleUnit.Id, Id);
            battleUnit.GridData.OnGridUnitEnter(battleUnit);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            // UI阻塞射线
            if (Stage.isTouchOnUI)
            {
                return;
            }

            var gridPos = WorldPosToGridPos(eventData.pointerCurrentRaycast.worldPosition);
            var gridData = m_Data.GetGridData(gridPos);
            if (gridData != null)
            {
                Log.Info("PointerDownGridMap {0}", gridPos);
                var battleUnit = gridData.GridUnit as BattleUnit;
                if (battleUnit != null)
                {
                    Log.Info("HP: {0}, QI: {1}", battleUnit.Data.HP, battleUnit.Data.QI);
                }
                GameEntry.Event.Fire(this, EventName.PointerDownGridMap, gridData);
            }
        }
    }
}
