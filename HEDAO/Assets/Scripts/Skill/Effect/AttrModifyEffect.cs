using HEDAO;
using UnityEngine;

namespace Cfg.Battle
{
    public partial class AttrModifyEffect
    {
        public override TakeEffectResult OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var targetUnit = target as Role;
            targetUnit.Attr.ModifyAttrDict(AttrDict);

            return default;
        }
        
        public override void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            var targetUnit = target as Role;
            var battleAttr = targetUnit.Attr;
        }
    }
}