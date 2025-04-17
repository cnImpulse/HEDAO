using UnityEngine;

namespace Cfg.Battle
{
    public partial class AttackEffect
    {
        public override TakeEffectResult OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var damage = -GetDamage(caster, target);
            target.Attr.ModifyAttr(EAttrType.HP, damage);

            return new TakeEffectResult { Damage = damage };
        }
        
        public override void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            
        }

        public override string GetDesc()
        {
            var str = string.Format("威力: {0}({1})", Powner, DamageType.GetName());
            return str;
        }

        public override string GetDesc(IEffectTarget caster, IEffectTarget target)
        {
            var str = string.Format("伤害: {0}({1})", GetDamage(caster, target), DamageType.GetName()); ;
            return str;
        }

        private int GetDamage(IEffectTarget caster, IEffectTarget target)
        {
            var damage = caster.Attr.STR + Powner - target.Attr.TPO;
            damage = Mathf.Clamp(damage, 0, damage);
            return damage;
        }
    }
}