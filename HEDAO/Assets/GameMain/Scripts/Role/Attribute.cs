using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace HEDAO
{
    public struct BattleProperty
    {
        public int MaxHP { get; private set; }  // 生命值
        public int MaxQI { get; private set; }  // 灵气值
        public int STR { get; private set; }
        public int TPO { get; private set; }
        public int SSI { get; private set; }

        public BattleProperty(Cfg.Battle.Property property)
        {
            MaxHP = property.MaxHP;
            MaxQI = property.MaxQI;
            STR = property.STR;
            TPO = property.TPO;
            SSI = property.SSI;
        }

        public static BattleProperty operator +(BattleProperty a, BattleProperty b)
        {
            return new BattleProperty
            {
                MaxHP = a.MaxHP + b.MaxHP,
                MaxQI = a.MaxQI + b.MaxQI,
                STR = a.STR + b.STR,
                TPO = a.TPO + b.TPO,
                SSI = a.SSI + b.SSI,
            };
        }

        public static BattleProperty operator -(BattleProperty a, BattleProperty b)
        {
            return new BattleProperty
            {
                MaxHP = a.MaxHP - b.MaxHP,
                MaxQI = a.MaxQI - b.MaxQI,
                STR = a.STR - b.STR,
                TPO = a.TPO - b.TPO,
                SSI = a.SSI - b.SSI,
            };
        }
    }
}