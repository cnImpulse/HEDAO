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
            var casterData = caster as BattleUnitData;
            var targetData = target as BattleUnitData;
             if (DamageType == EDamageType.Physics)
            {
                damage = Power + (casterData.RoleData?.STR ?? 0) - targetData.RoleData.TPO;
            }
            else if (DamageType == EDamageType.Magic)
            {
                damage = Power + (casterData.RoleData?.SSI ?? 0) - targetData.RoleData.FAS;
            }
            
            target.TakeDamage(Mathf.Max(0, damage));
        }
    }
}