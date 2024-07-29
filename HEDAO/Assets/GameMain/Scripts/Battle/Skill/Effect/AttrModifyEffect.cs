using HEDAO;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Cfg.Battle
{
    public partial class AttrModifyEffect
    {
        public override void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var targetUnit = target as BattleUnitData;
            targetUnit.RoleData.BattleAttr.ModifyAttr(AttrType, Value);
        }
        
        public override void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            var targetUnit = target as BattleUnitData;
            var battleAttr = targetUnit.RoleData.BattleAttr;
            battleAttr.SetAttr(AttrType, Mathf.Max(0, battleAttr.GetAttr(AttrType) - Value));
        }
    }
}