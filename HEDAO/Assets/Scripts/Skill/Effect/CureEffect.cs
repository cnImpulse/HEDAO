using UnityEngine;

namespace Cfg.Battle
{
    public class CureEffectResult : TakeEffectResult
    {
        public int Cure;
    }
    
    public partial class CureEffect
    {
        public override TakeEffectResult OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            var cure = GetCure(target);
            target.Attr.ModifyAttr(EAttrType.HP, cure);

            var result = new CureEffectResult { Cure = cure };
            return result;
        }
        
        public override void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            
        }

        public override string GetDesc()
        {
            var str = string.Format("治疗比例: {0:P0}", CureRate);
            return str;
        }

        public override string GetDesc(IEffectTarget caster, IEffectTarget target)
        {
            var str = string.Format("治疗: {0})", GetCure(target));
            return str;
        }

        public int GetCure(IEffectTarget target)
        {
            return Mathf.CeilToInt(target.Attr.MaxHP * CureRate);
        }
    }
}