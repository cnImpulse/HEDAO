namespace Cfg.Battle
{
    public partial class AddBuffEffect
    {
        public override void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            target.AddBuff(BuffId);
        }
    }
}