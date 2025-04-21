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
    public EWuXinType QiWuXinType
    {
        get
        {
            if (BookDict.TryGetValue(EBookType.DaoFa, out var id))
            {
                var cfg = GameMgr.Cfg.TbBook.Get(id);
                return cfg.WuXinType;
            }

            return EWuXinType.None;
        }
    }

    public HashSet<int> SkillSet = new HashSet<int>();
    public HashSet<int> MoveSkillSet = new HashSet<int>();
    public Dictionary<int, Buff> BuffDict = new Dictionary<int, Buff>();
    public HashSet<int> TagSet = new HashSet<int>();
    public Dictionary<EBookType, int> BookDict = new Dictionary<EBookType, int>();

    AttrComponent IEffectTarget.Attr => Attr;

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        var cfgId = (int)data;
        var cfg = GameMgr.Cfg.TbRole.Get(cfgId);
        Name = cfg.Name;
        Level = cfg.Level;

        Attr.Init(cfg.InitAttr);
        AddTag(cfg.RoleTag);
        foreach (var id in cfg.SkillSet)
        {
            SkillSet.Add(id);
        }
        MoveSkillSet.Add(cfg.MoveSkillId);
    }

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
}