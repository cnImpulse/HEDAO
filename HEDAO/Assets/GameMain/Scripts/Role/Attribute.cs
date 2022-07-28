using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace HEDAO
{
    public struct Attribute
    {
        public int MaxHP { get; private set; }  // 生命值
        public int MaxQI { get; private set; }  // 灵气值
        public int STR { get; private set; }
        public int TPO { get; private set; }
        public int SSI { get; private set; }

        public Attribute(Cfg.Battle.Attribute attribute)
        {
            MaxHP = attribute.MaxHP;
            MaxQI = attribute.MaxQI;
            STR = attribute.STR;
            TPO = attribute.TPO;
            SSI = attribute.SSI;
        }

        public static Attribute operator +(Attribute a, Attribute b)
        {
            return new Attribute
            {
                MaxHP = a.MaxHP + b.MaxHP,
                MaxQI = a.MaxQI + b.MaxQI,
                STR = a.STR + b.STR,
                TPO = a.TPO + b.TPO,
                SSI = a.SSI + b.SSI,
            };
        }

        public static Attribute operator -(Attribute a, Attribute b)
        {
            return new Attribute
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