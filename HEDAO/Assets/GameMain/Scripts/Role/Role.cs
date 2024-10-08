using System.Collections;
using System.Collections.Generic;
using Cfg;
using Cfg.Battle;
using GameFramework;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class Role : EntityData
    {
        public Dictionary<EWuXinType, int> WuXin { get; private set; }
        public AttributeDict BattleAttr { get; private set; }

        public Role(string name)
        {
            var cfg = GameEntry.Cfg.Tables.TbRoleTempCfg.Get(1);

            Name = name;
            BattleAttr = new AttributeDict();
            foreach (var pair in cfg.AttrRange)
            {
                BattleAttr.AddAttr(pair.Key, Random.Range(pair.Value.Min, pair.Value.Max));
            }
            
            WuXin = new Dictionary<EWuXinType, int>();
            for (int i = 0; i < 5; i++)
            {
                WuXin.Add((EWuXinType) i, Random.Range(cfg.WuXinRange.Min, cfg.WuXinRange.Max));
            }
        }
    }
}
