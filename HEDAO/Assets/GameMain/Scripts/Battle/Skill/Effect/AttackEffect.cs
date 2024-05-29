namespace Cfg.Battle
{
    public partial class AttackEffect
    {
        public override void OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            target.TakeDamage(Power);
        }
    }
}