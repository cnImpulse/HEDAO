using Cfg;
using Cfg.Battle;

public class CommonBuff : Buff
{
    public new CommonBuffCfg Cfg => base.Cfg as CommonBuffCfg;
        
    public CommonBuff(int id, Role caster, Role target) : base(id, caster, target)
    {

    }

    public override void OnAdd()
    {
        if (Target.CheckCondition(Cfg.ConditionId))
        {
            SetEffectActive(true);
        }
    }

    public override void OnRemove()
    {
        SetEffectActive(false);
    }
}
