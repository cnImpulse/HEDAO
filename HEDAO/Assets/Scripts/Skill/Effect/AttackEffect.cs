using UnityEngine;

namespace Cfg.Battle
{
    public partial class AttackEffect
    {
        public override TakeEffectResult OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var damage = -GetDamage(caster, target);
            target.Attr.ModifyAttr(EAttrType.HP, damage);

            var result = new TakeEffectResult();
            result.Damage = damage;
            return result;
        }
        
        public override void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            
        }

        public override string GetDesc()
        {
            var str = string.Format("伤害比例: {0:P0}({1})", DamageRate, DamageType.GetName());
            return str;
        }

        public override string GetDesc(IEffectTarget caster, IEffectTarget target)
        {
            var str = string.Format("伤害: {0}({1})", GetDamage(caster, target), DamageType.GetName()); ;
            return str;
        }

        private int GetDamage(IEffectTarget caster, IEffectTarget target)
        {
            var damage = Mathf.CeilToInt((caster.Attr.STR - target.Attr.TPO) * DamageRate); 
            damage = Mathf.Clamp(damage, 0, damage);
            return damage;
        }
    }
}