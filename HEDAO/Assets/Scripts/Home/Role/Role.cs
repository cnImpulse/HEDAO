using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class Role : Entity, IEffectTarget
{
    public string Name;
    public int Level { get; protected set; }

    public RoleAttrComponent Attr { get; protected set; } = new RoleAttrComponent();
    public Dictionary<EWuXinType, int> WuXin = new Dictionary<EWuXinType, int>();

    public Dictionary<EBookType, int> BookDict = new Dictionary<EBookType, int>();
    public HashSet<int> SkillSet = new HashSet<int>();
    public HashSet<int> TagSet = new HashSet<int>();

    private Dictionary<int, Buff> BuffDict = new Dictionary<int, Buff>();

    public void AddTag(int id)
    {
        TagSet.Add(id);
        var cfg = GameMgr.Cfg.TbRoleTagCfg.Get(id);
        EffectCfg.TakeEffectList(cfg.EffectList, null, this);
    }

    public void LevelUp(int level)
    {

    }
    
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