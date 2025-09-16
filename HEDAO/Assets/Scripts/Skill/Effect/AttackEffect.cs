using UnityEngine;

namespace Cfg.Battle
{
    public partial class AttackEffect
    {
        public override TakeEffectResult OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var range = caster.Attr.GetAtkRange();
            var atk = Random.Range(range.Min, range.Max + 1);
            
            var damage = -GetDamage(caster, target, atk);
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
            var range = caster.Attr.GetAtkRange();
            var str = string.Format("伤害: {0}-{1}({2})", GetDamage(caster, target, range.Min), 
                GetDamage(caster, target, range.Max), DamageType.GetName()); ;
            return str;
        }

        private int GetDamage(IEffectTarget caster, IEffectTarget target, int atk = 0)
        {
            var damage = Mathf.CeilToInt((atk + caster.Attr.STR - target.Attr.TPO) * DamageRate); 
            damage = Mathf.Clamp(damage, 0, damage);
            return damage;
        }
    }
}