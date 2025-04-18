namespace Cfg.Battle
{
    public partial class AddBuffEffect
    {
        public override TakeEffectResult OnTakeEffect(IEffectTarget caster, IEffectTarget target)
        {
            foreach(var buffId in BuffList)
            {
                target.AddBuff(buffId);
            }

            return default;
        }
    }
}