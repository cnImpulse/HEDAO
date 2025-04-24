using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class SkillComponent : Component
{
    public new Role Owner => base.Owner as Role;

    public HashSet<int> SkillSet = new HashSet<int>();
    public HashSet<int> MoveSkillSet = new HashSet<int>();
    public HashSet<int> TagSet = new HashSet<int>();

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        var cfg = Owner.InitCfg;
        AddTag(cfg.RoleTag);
        foreach (var id in cfg.SkillSet)
        {
            SkillSet.Add(id);
        }
        MoveSkillSet.Add(cfg.MoveSkillId);
    }

    public void AddTag(int id)
    {
        var cfg = GameMgr.Cfg.TbRoleTagCfg.GetOrDefault(id);
        if (cfg == null) return;

        TagSet.Add(id);
        EffectCfg.TakeEffectList(cfg.EffectList, null, Owner);
    }

    public void AddSkill(int id)
    {
        SkillSet.Add(id);
    }

    public void RemoveSkill(int id)
    {
        SkillSet.Remove(id);
    }
}
