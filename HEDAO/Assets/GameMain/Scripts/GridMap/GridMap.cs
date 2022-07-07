using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using GameFramework.Event;
using UnityGameFramework.Runtime;
using GameFramework.Resource;

namespace HEDAO
{
    /// <summary>
    /// 网格地图。
    /// </summary>
    public class GridMap : Entity
    {
        private Tilemap[] m_TilemapList = null;

        private GridMapData m_Data = null;

        public GridMapData Data => m_Data;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

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

            GameEntry.Entity.HideEntity(gridUnit);
            return true;
        }

        public void OnShowBattleUnitScuess(object sender, GameEventArgs e)
        {
            var ne = (ShowEntitySuccessEventArgs)e;

            var battleUnit = ne.Entity.Logic as BattleUnit;
            if (battleUnit == null)
            {
                return;
            }

            GameEntry.Entity.AttachEntity(battleUnit.Id, Id);
        }
    }
}
