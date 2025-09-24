namespace Cfg.Battle
{
    public partial class AddBuffEffect
    {
        public override TakeEffectResult OnTakeEffect(Role caster, Role target)
        {
            foreach(var buffId in BuffList)
            {
                target.Buff.AddBuff(buffId, caster.Battle.Owner);
            }

            return default;
        }
        
        public override string GetDesc()
        {
            return SkillUtil.GetBuffListDesc(BuffList);
        }

        public override string GetDesc(Role caster, Role target)
        {
            return GetDesc();
        }
    }
}