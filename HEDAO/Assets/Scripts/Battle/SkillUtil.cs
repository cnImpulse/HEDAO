using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;
using System.Linq;

public static class SkillUtil
{
    public static int GetHit(int skillId, Role caster, Role target)
    {
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        var hit = cfg.Hit;
        if (NeedCheckHit(cfg))
        {
            hit -= target.Attr.SEF;
        }

        return Mathf.Clamp(hit, GameMgr.Cfg.TbMisc.MinHit, 100);
    }

    public static bool NeedCheckHit(SkillCfg cfg)
    {
        return cfg.TargetType == ERelationType.Enemy;
    }

    public static string GetSkillDesc(int id)
    {
        var cfg = GameMgr.Cfg.TbSkill.Get(id);
        string str = "";
        if (NeedCheckHit(cfg))
        {
            str = string.Format("命中:{0}\n", cfg.Hit);
        }
        else
        {
            str = string.Format("目标:{0}\n", cfg.TargetType.GetName());
        }
        
        str += GetEffectDesc(cfg.EffectList);
        return str;
    }

    public static string GetSkillDesc(int id, Role caster, Role target)
    {
        string str = "";
        var cfg = GameMgr.Cfg.TbSkill.Get(id);
        if (NeedCheckHit(cfg))
        {
            str = string.Format("命中:{0}\n", GetHit(id, caster, target));
        }
        else
        {
            str = string.Format("目标:{0}\n", cfg.TargetType.GetName());
        }
        
        str += GetEffectDesc(cfg.EffectList, caster, target);
        return str;
    }

    public static string GetBuffListDesc(List<int> list)
    {
        return string.Join("\n", list.Select(id => GameMgr.Cfg.TbBuffCfg.Get(id)).Select(cfg => GetBuffDesc(cfg.Id)));
    }

    public static string GetBuffDesc(int id)
    {
        var cfg = GameMgr.Cfg.TbBuffCfg.Get(id);
        var str = cfg.Desc;
        // str += GetEffectDesc(cfg.EffectList);

        return str;
    }

    public static string GetEffectDesc(List<int> list)
    {
        return string.Join("\n", list.Select(id => GameMgr.Cfg.TbEffectCfg.Get(id)).Select(cfg => cfg.GetDesc()));
    }

    public static string GetEffectDesc(List<int> list, Role caster, Role target)
    {
        return string.Join("\n", list.Select(id => GameMgr.Cfg.TbEffectCfg.Get(id)).Select(cfg => cfg.GetDesc(caster, target)));
    }
}
