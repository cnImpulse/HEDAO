using UnityEngine;

namespace Cfg.Battle
{
    public partial class AttackEffect
    {
        public override TakeEffectResult OnTakeEffect(Role caster, Role target)
        {
            var range = caster.Attr.GetAtkRange();
            var atk = Random.Range(range.Min, range.Max + 1);
            
            var damage = GetDamage(caster, target, atk);
            var result = new TakeEffectResult();
            result.Damage = damage;
            
            var buff = target.Buff.GetBuff<ShieldBuff>();
            if (buff != null)
            {
                damage = buff.DecDurability(damage);
            }
            
            target.Attr.ModifyAttr(EAttrType.HP, -damage);
            return result;
        }
        
        public override string GetDesc()
        {
            var str = string.Format("伤害比例: {0:P0}({1})", DamageRate, DamageType.GetName());
            return str;
        }

        public override string GetDesc(Role caster, Role target)
        {
            var range = caster.Attr.GetAtkRange();
            var str = string.Format("伤害: {0}-{1}({2})", GetDamage(caster, target, range.Min), 
                GetDamage(caster, target, range.Max), DamageType.GetName()); ;
            return str;
        }

        private int GetDamage(Role caster, Role target, int atk = 0)
        {
            var damage = Mathf.CeilToInt((atk + caster.Attr.STR - target.Attr.TPO) * DamageRate); 
            damage = Mathf.Clamp(damage, 0, damage);
            return damage;
        }
    }
}