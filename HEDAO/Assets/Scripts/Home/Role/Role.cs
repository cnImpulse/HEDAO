using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class Role : Entity, IEffectTarget
{
    public string Name;
    public int Level { get; private set; }
    
    public Dictionary<EBookType, int> BookDict = new Dictionary<EBookType, int>();
    public HashSet<int> SkillSet = new HashSet<int>();

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

    public void RemoveBuff(int id)
    {
        if (BuffDict.TryGetValue(id, out var buff))
        {
            buff.OnRemove();
            BuffDict.Remove(id);
        }
    }

    public void AddSkill(int id)
    {
        SkillSet.Add(id);
    }

    public void RemoveSkill(int id)
    {
        SkillSet.Remove(id);
    }

    public void LearnGongFa(int cfgId)
    {
        var cfg = GameMgr.Cfg.Tables.TbGongFaCfg.Get(cfgId);
        if (BookDict.TryAdd(cfg.BookType, cfgId))
        {
            foreach(var buffId in cfg.BuffList)
            {
                AddBuff(buffId);
            }

            foreach (var skillId in cfg.SkillList)
            {
                AddSkill(skillId);
            }
        }
    }

    public void ForgetGongFa(int cfgId)
    {
        var cfg = GameMgr.Cfg.Tables.TbGongFaCfg.Get(cfgId);
        if (BookDict.ContainsKey(cfg.BookType))
        {
            BookDict.Remove(cfg.BookType);
            foreach(var buffId in cfg.BuffList)
            {
                RemoveBuff(buffId);
            }
            
            foreach (var skillId in cfg.SkillList)
            {
                RemoveSkill(skillId);
            }
        }
    }
}