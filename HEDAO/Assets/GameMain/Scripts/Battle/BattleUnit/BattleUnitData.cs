using System;
using UnityEngine;
using GameFramework.DataTable;
using System.Collections.Generic;

namespace HEDAO
{
    public class BattleUnitData : GridUnitData
    {
        public RoleData RoleData { get; private set; }

        public Attribute Attribute => BaseAttribute + ModifyAttribute;
        public Attribute BaseAttribute => RoleData.Attribute;
        public Attribute ModifyAttribute { get; set; }

        public int MOV => 10;
        public int MaxHP => Attribute.MaxHP;
        public int MaxQI => Attribute.MaxQI;

        private int m_HP = 0;
        public int HP
        {
            get => m_HP;
            set => m_HP = Mathf.Clamp(value, 0, MaxQI);
        }

        private int m_QI = 0;
        public int QI
        {
            get => m_QI;
            set => m_QI = Mathf.Clamp(value, 0, MaxQI);
        }

        public BattleUnitData(RoleData roleData, Vector2Int gridPos, CampType campType) : base(gridPos, campType)
        {
            RoleData = roleData;
            ModifyAttribute = default;

            HP = MaxHP;
            QI = MaxQI;
        }
    }
}