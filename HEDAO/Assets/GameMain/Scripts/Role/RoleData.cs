using System.Collections;
using System.Collections.Generic;
using Cfg;
using GameFramework;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class CharacterData
    {
        private int m_HP = 0;
        private int m_QI = 0;

        public int HP { get => m_HP; set => m_HP = Mathf.Clamp(value, 0, MaxHP); }
        public int QI { get => m_QI; set => m_QI = Mathf.Clamp(value, 0, MaxQI); }
        public int MaxHP => BattleAttr.GetAttr(EAttrType.MaxHP);
        public int MaxQI => BattleAttr.GetAttr(EAttrType.MaxQI);
        public int STR => BattleAttr.GetAttr(EAttrType.STR);
        public int TPO => BattleAttr.GetAttr(EAttrType.TPO);
        public int SSI => BattleAttr.GetAttr(EAttrType.SSI);
        public int Level { get; private set; }
        public int MoveSkillId { get; private set; }
        public string Name { get; private set; }
        public string Image { get; private set; }
        public HashSet<int> BattleSkillSet { get; private set; }

        public AttributeDict BattleAttr { get; private set; }
        
        public CharacterData(int roleId)
        {
            var cfg = GameEntry.Cfg.Tables.TbCharacter.Get(roleId);
            Name = cfg.Name;
            Image = cfg.Image;
            MoveSkillId = cfg.MoveSkillId;
            BattleSkillSet = cfg.SkillSet;

            BattleAttr = new AttributeDict();
            foreach (var pair in cfg.BaseAttr)
            {
                BattleAttr.AddAttr(pair.Key, (VarInt32)pair.Value, 0);
            }
            BattleAttr.AddAttr(EAttrType.Shield, 0, 0);
            
            Init();
        }

        private void Init()
        {
            Level = 0;
            HP = MaxHP;
            QI = MaxQI;
        }
    }
}
