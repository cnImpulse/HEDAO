using System;
using UnityEngine;

namespace HEDAO
{
    public class GridUnitData : EntityData
    {
        private Vector2Int m_GridPos;

        public GridUnitData(Vector2Int gridPos)
        {
            m_GridPos = gridPos;
            Name = "GridUnit";
        }

        public Vector2Int GridPos
        {
            get => m_GridPos;
            set => m_GridPos = value;
        }
    }
}