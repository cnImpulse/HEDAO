using HEDAO;
using UnityEngine;

namespace Cfg.Battle
{
    public interface IEffectTarget
    {
        void AddBuff(int id)
        {
            
        }

        void RemoveBuff(int id)
        {
            
        }

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
    }
}