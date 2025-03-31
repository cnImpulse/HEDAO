using System.Collections.Generic;
using HEDAO;
using UnityEngine;

namespace Cfg.Battle
{
    public interface IEffectTarget
    {
        void AddBuff(int id);
        void RemoveBuff(int id);
        void AddSkill(int id);
        bool CheckCondition(int id);
        void TakeDamage(int damage)
        {
            
        }
    }
    
    public partial class EffectCfg
    {
        public virtual void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            
        }

        public virtual void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            
        }

        public static void TakeEffectList(List<int> list, IEffectTarget caster, IEffectTarget target)
        {
            foreach(var id in list)
            {
                var cfg = GameMgr.Cfg.TbEffectCfg.Get(id);
                cfg.OnTakeEffect(caster, target);
            }
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