using System;
using UnityEngine;
using GameFramework.DataTable;
using System.Collections.Generic;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class BattleUnitData : GridUnitData
    {
        public CharacterData RoleData { get; private set; }

        public int HP
        {
            get => RoleData.HP;
            set
            {
                if (value <= 0)
                {
                    GameEntry.Event.Fire(this, EventName.BattleUnitDead, (VarInt32)Id);
                }
                RoleData.HP = value;
            }
        }
        public int QI { get => RoleData.QI; set => RoleData.QI = value; }
        public int MaxHP => RoleData.MaxHP;
        public int MaxQI => RoleData.MaxQI;
        public int STR => RoleData.STR;
        public int TPO => RoleData.TPO;
        public int SSI => RoleData.SSI;

        public int MoveSkillId => RoleData.MoveSkillId;
        public int MOV
        {
            get
            {
                var cfg = GameEntry.Cfg.Tables.TbMoveSkillCfg.Get(MoveSkillId);
                return cfg.MOV;
            }
        }

        public BattleUnitData(CharacterData roleData, Vector2Int gridPos, CampType campType) : base(gridPos, campType)
        {
            RoleData = roleData;
            Name = string.Format("{0}-{1}", roleData.Name, Id);
        }
    }
}