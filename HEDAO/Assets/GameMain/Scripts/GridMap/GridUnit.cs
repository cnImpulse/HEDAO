using GameFramework;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityGameFramework.Runtime;
using HEDAO.Skill;

namespace HEDAO
{
    /// <summary>
    /// 网格单位。
    /// </summary>
    public class GridUnit : Entity
    {
        protected SpriteRenderer m_SpriteRenderer = null;
        
        private GridUnitData m_Data = null;

        public new GridUnitData Data => m_Data;

        public GridMap GridMap { get; private set; }
        public GridData GridData => GridMap.Data.GetGridData(Data.GridPos);
        public int GridIndex => GridMapUtl.GridPosToIndex(Data.GridPos);

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            
            m_SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            
            m_Data = userData as GridUnitData;
            
            m_SpriteRenderer.color = BattleUtl.GetCampColor(Data.CampType);
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            GameEntry.Entity.DetachEntity(Id);

            base.OnHide(isShutdown, userData);
        }

        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            GridMap = parentEntity as GridMap;
            transform.position = GridMap.GridPosToWorldPos(m_Data.GridPos);
            GridData.OnGridUnitEnter(this);
        }

        protected override void OnDetachFrom(EntityLogic parentEntity, object userData)
        {
            GridData.OnGridUnitLeave();
            GridMap = null;

            base.OnDetachFrom(parentEntity, userData);
        }
    }
}
