using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;

public class Role : Entity
{
    public string Name;
    public Dictionary<EWuXinType, int> WuXin { get; private set; }
    public AttributeDict BattleAttr { get; private set; }

    public void Init(string name)
    {
        Name = name;
        var cfg = GameMgr.Cfg.Tables.TbRoleTempCfg.Get(1);

        BattleAttr = new AttributeDict();
        foreach (var pair in cfg.AttrRange)
        {
            BattleAttr.AddAttr(pair.Key, Random.Range(pair.Value.Min, pair.Value.Max));
        }

        WuXin = new Dictionary<EWuXinType, int>();
        for (int i = 0; i < 5; i++)
        {
            WuXin.Add((EWuXinType)i, Random.Range(cfg.WuXinRange.Min, cfg.WuXinRange.Max));
        }
    }
}