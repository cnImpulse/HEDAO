using HEDAO;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Cfg.Battle
{
    public partial class AttrModifyEffect
    {
        public override void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var targetUnit = target as BattleUnit;
            targetUnit.Data.RoleData.BattleAttr.ModifyAttr<VarInt32>(AttrType, Value);
        }
        
        public override void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            var targetUnit = target as BattleUnit;
            var battleAttr = targetUnit.Data.RoleData.BattleAttr;
            battleAttr.SetAttr(AttrType, Mathf.Max(0, battleAttr.GetAttr<int>(AttrType) - Value));
        }
    }
}