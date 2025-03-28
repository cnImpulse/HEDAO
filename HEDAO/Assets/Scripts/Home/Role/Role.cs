using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;

public class Role : Entity
{
    public string Name;
    public int Level { get; private set; }

    public Dictionary<EWuXinType, int> WuXin { get; private set; }
    public AttributeDict BattleAttr { get; private set; }

    public void Init(string name)
    {
        Name = name;
        Level = 1;
        var cfg = GameMgr.Cfg.Tables.TbRoleTempCfg.Get(1);

        BattleAttr = new AttributeDict();
        BattleAttr.ModifyAttrDict(cfg.InitAttr);

        WuXin = new Dictionary<EWuXinType, int>();
        for (int i = 0; i < 5; i++)
        {
            WuXin.Add((EWuXinType)i, Random.Range(cfg.WuXinRange.Min, cfg.WuXinRange.Max));
        }
    }

    public void LevelUp(int level)
    {

    }
}