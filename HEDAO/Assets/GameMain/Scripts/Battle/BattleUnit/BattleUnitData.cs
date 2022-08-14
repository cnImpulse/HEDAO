using System;
using UnityEngine;
using GameFramework.DataTable;
using System.Collections.Generic;

namespace HEDAO
{
    public class BattleUnitData : GridUnitData
    {
        public RoleData RoleData { get; private set; }

        public Attribute Attribute => RoleAttribute + ModifyAttribute;
        public Attribute RoleAttribute => RoleData.Attribute;
        public Attribute ModifyAttribute { get; set; }

        public int HP { get => RoleData.HP; set => RoleData.HP = value; }
        public int QI { get => RoleData.QI; set => RoleData.QI = value; }
        public int MaxHP => Attribute.MaxHP;
        public int MaxQI => Attribute.MaxQI;
        public int STR => Attribute.STR;
        public int TPO => Attribute.TPO;
        public int SSI => Attribute.SSI;

        public int MoveSkillId => RoleData.MoveSkillId;
        public int MOV
        {
            get
            {
                var cfg = GameEntry.Cfg.Tables.TbMoveSkillCfg.Get(MoveSkillId);
                return cfg.MOV;
            }
        }

        public BattleUnitData(RoleData roleData, Vector2Int gridPos, CampType campType) : base(gridPos, campType)
        {
            RoleData = roleData;
            ModifyAttribute = default;
            Name = string.Format("{0}-{1}", roleData.Name, Id);
        }
    }
}