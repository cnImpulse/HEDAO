using System.Collections.Generic;
using HEDAO;
using UnityEngine;

namespace Cfg.Battle
{
    public interface IEffectTarget
    {
        AttrComponent Attr { get; }

        void AddBuff(int id);
        void RemoveBuff(int id);
        void AddSkill(int id);
        bool CheckCondition(int id);
    }

    public class TakeEffectResult
    {
        public int Damage;
    }
    
    public partial class EffectCfg
    {
        public virtual TakeEffectResult OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            return null;
        }

        public virtual void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            
        }

        public virtual string GetDesc()
        {
            return null;
        }

        public virtual string GetDesc(IEffectTarget caster, IEffectTarget target)
        {
            return null;
        }

        public static List<TakeEffectResult> TakeEffectList(List<int> list, IEffectTarget caster, IEffectTarget target)
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

        public static void ResetEffectList(List<int> list, IEffectTarget caster, IEffectTarget target)
        {
            foreach (var id in list)
            {
                var cfg = GameMgr.Cfg.TbEffectCfg.Get(id);
                cfg.OnResetEffect(caster, target);
            }
        }
    }
}