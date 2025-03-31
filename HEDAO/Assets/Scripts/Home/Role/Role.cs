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
    public HashSet<int> TagSet = new HashSet<int>();

    public Dictionary<EWuXinType, int> WuXin { get; private set; }
    public AttributeDict BattleAttr { get; private set; }

    public void Init(string name)
    {
        Name = name;
        Level = 1;
        var cfg = GameMgr.Cfg.TbRoleTempCfg.Get(1);

        BattleAttr = new AttributeDict();
        BattleAttr.ModifyAttrDict(cfg.InitAttr);
        ResetBattleState();

        WuXin = new Dictionary<EWuXinType, int>();
        for (int i = 0; i < 5; i++)
        {
            WuXin.Add((EWuXinType)i, Random.Range(cfg.WuXinRange.Min, cfg.WuXinRange.Max));
        }

        var tagList = GameMgr.Cfg.TbRoleTagCfg.DataList;
        AddTag(tagList[Random.Range(0, tagList.Count)].Id);
    }

    public void AddTag(int id)
    {
        TagSet.Add(id);
        var cfg = GameMgr.Cfg.TbRoleTagCfg.Get(id);
        EffectCfg.TakeEffectList(cfg.EffectList, null, this);
    }

    public void ResetBattleState()
    {
        BattleAttr.InitAttr(EAttrType.HP, BattleAttr.GetAttr(EAttrType.MaxHP), 0, BattleAttr.GetAttr(EAttrType.MaxHP));
        BattleAttr.InitAttr(EAttrType.QI, BattleAttr.GetAttr(EAttrType.MaxQI), 0, BattleAttr.GetAttr(EAttrType.MaxQI));
    }

    public void LevelUp(int level)
    {

    }

    private Dictionary<int, Buff> BuffDict = new Dictionary<int, Buff>();

    public void AddBuff(int id)
    {
        RemoveBuff(id);

        var buff = new CommonBuff(id, this);
        BuffDict.Add(id, buff);
        buff.OnAdd();
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

    public bool CheckCondition(int id)
    {
        if (!GameMgr.Cfg.TbConditionCfg.DataMap.ContainsKey(id))
        {
            return true;
        }
        
        var cfg = GameMgr.Cfg.TbConditionCfg.Get(id);
        return Level >= cfg.Level;
    }

    public void RemoveSkill(int id)
    {
        SkillSet.Remove(id);
    }

    public void LearnGongFa(int cfgId)
    {
        var cfg = GameMgr.Cfg.TbGongFaCfg.Get(cfgId);
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
        var cfg = GameMgr.Cfg.TbGongFaCfg.Get(cfgId);
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