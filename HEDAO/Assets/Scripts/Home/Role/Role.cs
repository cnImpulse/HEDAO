using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class Role : Entity, IEffectTarget
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

    private Dictionary<int, Buff> BuffDict = new Dictionary<int, Buff>();

    public void AddBuff(int id)
    {
        RemoveBuff(id);

        var buff = new Buff(id, this);
        BuffDict.Add(id, buff);
    }

    void RemoveBuff(int id)
    {
        if (BuffDict.TryGetValue(id, out var buff))
        {
            buff.OnRemove();
            BuffDict.Remove(id);
        }
    }

    public void LearnGongFa(int cfgId)
    {
        var cfg = GameMgr.Cfg.Tables.TbGongFaCfg.Get(cfgId);
        foreach(var buffId in cfg.BuffList)
        {
            AddBuff(buffId);
        }
    }

    public void ForgetGongFa(int cfgId)
    {
        var cfg = GameMgr.Cfg.Tables.TbGongFaCfg.Get(cfgId);
        foreach (var buffId in cfg.BuffList)
        {
            RemoveBuff(buffId);
        }
    }
}