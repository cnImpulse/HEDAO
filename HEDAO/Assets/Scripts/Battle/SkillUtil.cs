using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;
using System.Linq;

public static class SkillUtil
{
    public static int GetHit(int skillId, IEffectTarget caster, IEffectTarget target)
    {
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        var hit = cfg.Hit;
        hit -= target.Attr.SEF;

        return Mathf.Clamp(hit, GameMgr.Cfg.TbMisc.MinHit, 100);
    }

    public static string GetSkillDesc(int id)
    {
        var cfg = GameMgr.Cfg.TbSkill.Get(id);
        var str = string.Format("命中:{0}\n", cfg.Hit);
        str += GetEffectDesc(cfg.EffectList);
        return str;
    }

    public static string GetSkillDesc(int id, IEffectTarget caster, IEffectTarget target)
    {
        var cfg = GameMgr.Cfg.TbSkill.Get(id);
        var str = string.Format("命中:{0}\n", GetHit(id, caster, target));
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
        var str = cfg.Desc + ": ";
        str += GetEffectDesc(cfg.EffectList);

        return str;
    }

    public static string GetEffectDesc(List<int> list)
    {
        return string.Join("\n", list.Select(id => GameMgr.Cfg.TbEffectCfg.Get(id)).Select(cfg => cfg.GetDesc()));
    }

    public static string GetEffectDesc(List<int> list, IEffectTarget caster, IEffectTarget target)
    {
        return string.Join("\n", list.Select(id => GameMgr.Cfg.TbEffectCfg.Get(id)).Select(cfg => cfg.GetDesc(caster, target)));
    }
}
