using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using GameFramework.Event;
using HEDAO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class GridMap : Entity, IPointerDownHandler
    {
        protected Tilemap[] m_TilemapList = null;
        protected BattleMapData m_Data = null;
        public new BattleMapData Data => m_Data;

        protected Dictionary<int, GridUnit> m_GridUnitDic = default;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_GridUnitDic = new Dictionary<int, GridUnit>();
            m_TilemapList = GetComponentsInChildren<Tilemap>();
            m_TilemapList[0].gameObject.GetOrAddComponent<BoxCollider2D>();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_Data = userData as BattleMapData;
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            foreach (var gridUnit in m_GridUnitDic.Values)
            {
                GameEntry.Entity.HideEntity(gridUnit);
            }
            m_GridUnitDic.Clear();
            
            base.OnHide(isShutdown, userData);
        }

        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);

            var gridUnit = childEntity as GridUnit;
            m_GridUnitDic.Add(gridUnit.Id, gridUnit);
        }

        protected override void OnDetached(EntityLogic childEntity, object userData)
        {
            var gridUnit = childEntity as GridUnit;
            m_GridUnitDic.Remove(gridUnit.Id);

            base.OnDetached(childEntity, userData);
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