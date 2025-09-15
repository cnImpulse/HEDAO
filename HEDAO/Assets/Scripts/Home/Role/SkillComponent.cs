using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class SkillComponent : Component
{
    public new Role Owner => base.Owner as Role;

    public HashSet<int> SkillSet = new HashSet<int>();
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

    public List<int> GetValidSkillList(BattleData data)
    {
        var list = new List<int>();
        foreach (var skillId in SkillSet)
        {
            var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
            if (Owner.Attr.QI <= cfg.Cost)
            {
                continue;
            }

            if (!cfg.LaunchPos.Contains(Owner.Battle.PosIndex))
            {
                continue;
            }

            var targetList = GameMgr.Battle.Data.GetRoleList(cfg.TargetPos, !Owner.Battle.IsLeft);
            if (targetList.Count == 0)
            {
                continue;
            }
            
            list.Add(skillId);
        }
        
        return list;
    }
}
