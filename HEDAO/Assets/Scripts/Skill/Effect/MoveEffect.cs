using UnityEngine;

namespace Cfg.Battle
{
    public partial class MoveEffect
    {
        public override TakeEffectResult OnTakeEffect(Role caster, Role target)
        {
            if (TargetType == EEffectTargetType.Caster)
            {
                target = caster;
            }
            else if(GameMgr.Battle.CheckHit(GetRatio(caster, target)))
            {
                return default;
            }
            
            GameMgr.Battle.Data.MoveBattleUnit(target.Battle.Owner, Distance);
            return default;
        }
        
        public override string GetDesc()
        {
            var str = string.Format("{0}{1}{2}", TargetType == EEffectTargetType.Caster ? "" : "目标",
                Distance < 0 ? "前进" : "后退", Mathf.Abs(Distance));
            return str;
        }

        public override string GetDesc(Role caster, Role target)
        {
            var str = GetDesc();
            if (TargetType != EEffectTargetType.Caster)
            {
                str += string.Format("(概率{0}%)", GetRatio(caster, target));
            }
            
            return str;
        }

        public int GetRatio(Role caster, Role target)
        {
            return 50 + 10 * (caster.Attr.TPO - target.Attr.TPO);
        }
    }
}