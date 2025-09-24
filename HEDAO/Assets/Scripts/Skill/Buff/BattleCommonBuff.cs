using Cfg;
using Cfg.Battle;

public class BattleCommonBuff : BattleBuff
{
    public new BattleCommonBuffCfg Cfg => base.Cfg as BattleCommonBuffCfg;
        
    public BattleCommonBuff(int id, Role caster, Role target) : base(id, caster, target)
    {

    }

    public override void OnAdd()
    {
        base.OnAdd();
        SetEffectActive(true);
    }

    public override void OnRemove()
    { 
        SetEffectActive(false);
        base.OnRemove();
    }
}
