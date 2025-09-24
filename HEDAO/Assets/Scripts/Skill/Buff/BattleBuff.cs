using Cfg;
using Cfg.Battle;

public class BattleBuff : Buff
{
    public int Life = 0;
    public new BattleBuffCfg Cfg => base.Cfg as BattleBuffCfg;
        
    public BattleBuff(int id, Role caster, Role target) : base(id, caster, target)
    {

    }

    public override void OnAdd()
    {
        Life = Cfg.Round;
        Target.Battle.OnRoundStart += OnRoundStart;
    }

    public virtual void OnRoundStart()
    {
        Life--;
        RoundEffect();
        if (Life <= 0)
        {
            Remove();
        }
    }
    
    public override void OnRemove()
    {
        Target.Battle.OnRoundStart -= OnRoundStart;
    }

    public virtual void RoundEffect()
    {
        
    }
}
