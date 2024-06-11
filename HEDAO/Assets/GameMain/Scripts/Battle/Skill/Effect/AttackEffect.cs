using HEDAO;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Cfg.Battle
{
    public partial class AttackEffect
    {
        public override void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var damage = Power;
            var casterUnit = caster as BattleUnit;
            var targetUnit = target as BattleUnit;
             if (DamageType == EDamageType.Physics)
            {
                damage = Power + (casterUnit?.Data?.RoleData?.STR ?? 0) - targetUnit.Data.RoleData.TPO;
            }
            else if (DamageType == EDamageType.Magic)
            {
                damage = Power + (casterUnit?.Data?.RoleData?.SSI ?? 0) - targetUnit.Data.RoleData.FAS;
            }
            
            target.TakeDamage(Mathf.Max(0, damage));
        }
    }
}