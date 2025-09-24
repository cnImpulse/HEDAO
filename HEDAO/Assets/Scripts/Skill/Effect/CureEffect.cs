using UnityEngine;

namespace Cfg.Battle
{
    public class CureEffectResult : TakeEffectResult
    {
        public int Cure;
    }
    
    public partial class CureEffect
    {
        public override TakeEffectResult OnTakeEffect(Role caster, Role target)
        {
            var cure = GetCure(target);
            target.Attr.ModifyAttr(EAttrType.HP, cure);

            var result = new CureEffectResult { Cure = cure };
            return result;
        }
        
        public override string GetDesc()
        {
            var str = string.Format("治疗比例: {0:P0}", CureRate);
            return str;
        }

        public override string GetDesc(Role caster, Role target)
        {
            var str = string.Format("治疗: {0}", GetCure(target));
            return str;
        }

        public int GetCure(Role target)
        {
            return Mathf.CeilToInt(target.Attr.MaxHP * CureRate);
        }
    }
}