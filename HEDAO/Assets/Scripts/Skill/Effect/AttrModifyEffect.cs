using HEDAO;
using UnityEngine;

namespace Cfg.Battle
{
    public partial class AttrModifyEffect
    {
        public override void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var targetUnit = target as Role;
            targetUnit.BattleAttr.ModifyAttrDict(AttrDict);
        }
        
        public override void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            var targetUnit = target as Role;
            var battleAttr = targetUnit.BattleAttr;
        }
    }
}