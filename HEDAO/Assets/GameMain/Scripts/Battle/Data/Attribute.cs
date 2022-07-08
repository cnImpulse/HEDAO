using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace HEDAO
{
    public struct Attribute
    {
        public int HP  { get; private set; }  // 生命值
        public int QI  { get; private set; }  // 灵气值

        public Attribute(Cfg.Battle.Attribute attribute)
        {
            HP = attribute.HP;
            QI = attribute.QI;
        }

        public static Attribute operator +(Attribute a, Attribute b)
        {
            return new Attribute
            {
                HP = a.HP + b.HP,
                QI = a.QI + b.QI,
            };
        }
    }
}