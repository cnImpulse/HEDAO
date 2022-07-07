using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace HEDAO
{
    public struct Attribute
    {
        public int HP  { get; private set; }  // 生命值
        public int MOV { get; private set; }  // 移动力
        public int STR { get; private set; }  // 力量

        public Attribute(Cfg.Battle.Attribute attribute)
        {
            HP = attribute.HP;
            MOV = attribute.MOV;
            STR = attribute.STR;
        }

        public static Attribute operator +(Attribute a, Attribute b)
        {
            return new Attribute
            {
                HP = a.HP + b.HP,
                MOV = a.MOV + b.MOV,
                STR = a.STR + b.STR,
            };
        }

        public static Attribute operator *(Attribute a, int k)
        {
            return new Attribute
            {
                HP = a.HP * k,
                MOV = a.MOV * k,
                STR = a.STR * k,
            };
        }
    }
}