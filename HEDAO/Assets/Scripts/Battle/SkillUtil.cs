using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;
using System.Linq;

public static class SkillUtil
{
    public static string GetSkillDesc(int id)
    {
        var cfg = GameMgr.Cfg.TbSkill.Get(id);
        var str = string.Format("释放距离:{0} 命中:{1}\n", cfg.ReleaseRange.Distance, cfg.Hit);
        foreach (var effectId in cfg.EffectList)
        {
            str += GetEffectDesc(effectId) + '\n';
        }

        return str;
    }

    public static string GetBuffDesc(int id)
    {
        var cfg = GameMgr.Cfg.TbBuffCfg.Get(id);
        var str = cfg.Desc + ": ";
        foreach (var effectId in cfg.EffectList)
        {
            str += GetEffectDesc(effectId) + '\n';
        }

        return str;
    }

    public static string GetEffectDesc(int id)
    {
        var str = "";
        var cfg = GameMgr.Cfg.TbEffectCfg.Get(id);
        if (cfg is AttrModifyEffect)
        {
            foreach (var pair in ((AttrModifyEffect)cfg).AttrDict)
            {
                str += string.Format("{0}:{1} ", pair.Key.GetName(), pair.Value);
            }
        }
        else if (cfg is AttackEffect atkCfg)
        {
            str += string.Format("威力 {0}:{1} ", atkCfg.DamageType.GetName(), atkCfg.Powner);
        }

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
