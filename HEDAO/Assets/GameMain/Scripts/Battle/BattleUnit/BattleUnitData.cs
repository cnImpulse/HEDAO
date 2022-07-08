using System;
using UnityEngine;
using GameFramework.DataTable;
using System.Collections.Generic;

namespace HEDAO
{
    public class BattleUnitData : GridUnitData
    {
        public CampType CampType { get; private set; }
        public RoleData RoleData { get; private set; }

        public int MaxHP => RoleData.Attribute.HP;
        public int MaxQI => RoleData.Attribute.QI;

        private int m_HP = 0;
        public int HP
        {
            get => m_HP;
            set => Mathf.Clamp(m_HP, 0, MaxHP);
        }

        private int m_QI = 0;
        public int QI
        {
            get => m_HP;
            set => Mathf.Clamp(m_QI, 0, MaxQI);
        }

        public BattleUnitData(RoleData roleData, Vector2Int gridPos, CampType campType) : base(gridPos)
        {
            RoleData = roleData;
            CampType = campType;
        }
    }
}