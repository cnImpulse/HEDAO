using UnityGameFramework.Runtime;

namespace Cfg.Battle
{
    public partial class AttrModifyEffect
    {
        public override void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            target.ModifyAttr<VarInt32>(AttrType, Value);
        }
        
        public override void OnResetEffect(IEffectTarget caster, IEffectTarget target)
        {
            target.ModifyAttr<VarInt32>(AttrType, -Value);
        }
    }
}