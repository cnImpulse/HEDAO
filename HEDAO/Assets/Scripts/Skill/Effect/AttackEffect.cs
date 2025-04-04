using HEDAO;
using UnityEngine;

namespace Cfg.Battle
{
    public partial class AttackEffect
    {
        public override void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var damage = caster.Attr.STR + Powner - target.Attr.TPO;
            damage = Mathf.Clamp(damage, 0, damage);
            target.Attr.ModifyAttr(EAttrType.HP, -damage);
        }
        
        public override void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            
        }
    }
}