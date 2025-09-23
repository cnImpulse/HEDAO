using UnityEngine;

namespace Cfg.Battle
{
    public partial class MoveEffect
    {
        public override TakeEffectResult OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            if (TargetType == EEffectTargetType.Caster)
            {
                target = caster;
            }

            GameMgr.Battle.Data.MoveBattleUnit(target.Battle.Owner, Distance);
            
            return default;
        }
        
        public override void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            
        }

        public override string GetDesc()
        {
            var str = string.Format("{0}{1}{2}", TargetType == EEffectTargetType.Caster ? "" : "目标",
                Distance < 0 ? "前进" : "后退", Mathf.Abs(Distance));
            return str;
        }

        public override string GetDesc(IEffectTarget caster, IEffectTarget target)
        {
            var str = GetDesc();
            return str;
        }
    }
}