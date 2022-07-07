using System;
using UnityEngine;
using GameFramework.DataTable;
using System.Collections.Generic;

namespace HEDAO
{
    public class BattleUnitData : GridUnitData
    {
        private RoleData m_RoleData = null;

        private CampType m_CampType = CampType.None;

        private int m_Hp = 0;

        public RoleData RoleData => m_RoleData;

        public int Hp
        {
            get => m_Hp;
            set => Mathf.Clamp(m_Hp, 0, MaxHp);
        }

        public int MaxHp => m_RoleData.Attribute.HP;
        public int MOV => m_RoleData.Attribute.MOV;
        public int ATK => m_RoleData.Attribute.STR;
        public CampType CampType => m_CampType;

        public BattleUnitData(RoleData roleData, Vector2Int gridPos, CampType campType) : base(gridPos)
        {
            m_RoleData = roleData;
            m_CampType = campType;
        }
    }
}