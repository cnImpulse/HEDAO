using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class CharacterData
    {
        private int m_HP = 0;
        private int m_QI = 0;

        public int HP { get => m_HP; set => m_HP = Mathf.Clamp(value, 0, MaxHP); }
        public int QI { get => m_QI; set => m_QI = Mathf.Clamp(value, 0, MaxQI); }
        public int MaxHP => Attribute.MaxHP;
        public int MaxQI => Attribute.MaxQI;
        public int STR => Attribute.STR;
        public int TPO => Attribute.TPO;
        public int SSI => Attribute.SSI;
        public int Level { get; private set; }
        public int MoveSkillId { get; private set; }
        public string Name { get; private set; }
        public string Image { get; private set; }
        public BattleProperty BaseAttribute { get; private set; }
        public BattleProperty Attribute => BaseAttribute;
        public HashSet<int> BattleSkillSet { get; private set; }

        public CharacterData(int roleId)
        {
            var cfg = GameEntry.Cfg.Tables.TbCharacter.Get(roleId);
            Name = cfg.Name;
            Image = cfg.Image;
            BaseAttribute = new BattleProperty(cfg.BaseProperty);
            MoveSkillId = cfg.MoveSkillId;
            BattleSkillSet = cfg.SkillSet;

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
