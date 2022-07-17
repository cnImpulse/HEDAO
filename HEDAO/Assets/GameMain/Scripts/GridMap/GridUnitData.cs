using System;
using UnityEngine;

namespace HEDAO
{
    public class GridUnitData : EntityData
    {
        public CampType CampType { get; private set; }

        private Vector2Int m_GridPos;

        public GridUnitData(Vector2Int gridPos, CampType campType)
        {
            m_GridPos = gridPos;
            CampType = campType;
            Name = "GridUnit";
        }

        public Vector2Int GridPos
        {
            get => m_GridPos;
            set => m_GridPos = value;
        }
    }
}