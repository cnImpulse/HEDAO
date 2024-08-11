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
        private GridUnitData m_Data = null;

        public new GridUnitData Data => m_Data;

        public BattleMap BattleMap { get; private set; }
        public GridData GridData => BattleMap.Data.GetGridData(Data.GridPos);
        public int GridIndex => GridMapUtl.GridPosToIndex(Data.GridPos);

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_Data = userData as GridUnitData;
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            GameEntry.Entity.DetachEntity(Id);

            base.OnHide(isShutdown, userData);
        }

        protected override void OnAttachTo(EntityLogic parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            BattleMap = parentEntity as BattleMap;
            transform.position = BattleMap.GridPosToWorldPos(m_Data.GridPos);
            GridData.OnGridUnitEnter(this);
        }

        protected override void OnDetachFrom(EntityLogic parentEntity, object userData)
        {
            GridData.OnGridUnitLeave();
            BattleMap = null;

            base.OnDetachFrom(parentEntity, userData);
        }
    }
}
