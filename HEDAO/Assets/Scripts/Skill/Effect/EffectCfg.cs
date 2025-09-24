using System.Collections.Generic;
using HEDAO;
using UnityEngine;

namespace Cfg.Battle
{
    public class TakeEffectResult
    {
        public int Damage;
    }
    
    public partial class EffectCfg
    {
        public virtual TakeEffectResult OnTakeEffect(Role caster, Role target)
        {
            return null;
        }

        public virtual void OnResetEffect(Role caster, Role target)
        {
            
        }

        public virtual string GetDesc()
        {
            return null;
        }

        public virtual string GetDesc(Role caster, Role target)
        {
            return null;
        }

        public static List<TakeEffectResult> TakeEffectList(List<int> list, Role caster, Role target)
        {
            List<TakeEffectResult> results = new List<TakeEffectResult>();
            foreach(var id in list)
            {
                var cfg = GameMgr.Cfg.TbEffectCfg.Get(id);
                var result = cfg.OnTakeEffect(caster, target);
                if (result != null) results.Add(result);
            }

            return results;
        }

        public static void ResetEffectList(List<int> list, Role caster, Role target)
        {
            foreach (var id in list)
            {
                var cfg = GameMgr.Cfg.TbEffectCfg.Get(id);
                cfg.OnResetEffect(caster, target);
            }
        }
    }
}