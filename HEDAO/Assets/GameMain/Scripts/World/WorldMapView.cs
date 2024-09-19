using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HEDAO;
using UnityEngine;
using LDtkUnity;
using UnityEngine.Tilemaps;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class WorldMapView : EntityView
    {
        protected Tilemap[] m_TilemapList = null;
        
        protected List<LDtkComponentEntity> EntityList = new List<LDtkComponentEntity>();
        public new WorldMap Data { get; private set; }
        
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            m_TilemapList = GetComponentsInChildren<Tilemap>();
            
            InitEntityList();
        }
        
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            Data = userData as WorldMap;
            ShowAllGridUnit();
        }
        
        protected override void OnAttached(EntityLogic childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);

            var gridUnit = childEntity as WorldGridUnitView;
        }

        protected override void OnDetached(EntityLogic childEntity, object userData)
        {
            var gridUnit = childEntity as WorldGridUnitView;
            base.OnDetached(childEntity, userData);
        }

        private void InitEntityList()
        {
            EntityList.Clear();
            var project = GetComponent<LDtkComponentProject>();
            foreach (var world in project.Worlds)
            {
                foreach (var level in world.Levels)
                {
                    foreach (var layer in level.LayerInstances)
                    {
                        foreach (var entity in layer.EntityInstances)
                        {
                            EntityList.Add(entity);
                        }
                    }
                }
            }
        }

        private void ShowAllGridUnit()
        {
            foreach (var entity in EntityList)
            {
                Data.RegisterGridUnit(entity.Grid, entity);
            }
        }
        
        public Vector3 GridPosToWorldPos(Vector2Int gridPos)
        {
            return m_TilemapList[0].GetCellCenterWorld((Vector3Int)gridPos);
        }
    }
}