using Cfg;
using Cfg.Battle;
using Newtonsoft.Json;

public abstract class Buff
{
    public int Id { get; private set; }
    public Role Caster { get; private set; }
    public Role Target { get; private set; }
    public bool IsEffectActive { get; private set; } = false;
    
    public BuffCfg Cfg => GameMgr.Cfg.TbBuffCfg.Get(Id);
    
    public Buff(int id, Role caster, Role target)
    {
        Id = id;
        Caster = caster;
        Target = target;
    }

    public virtual void OnAdd()
    {

    }

    public virtual void OnRemove()
    {

    }

    public virtual void SetEffectActive(bool active)
    {
        if (IsEffectActive == active) return;

        IsEffectActive = active;
        foreach (var effectId in Cfg.EffectList)
        {
            var effectCfg = GameMgr.Cfg.TbEffectCfg.Get(effectId);
            if (active)
            {
                effectCfg.OnTakeEffect(null, Target);
            }
            else
            {
                effectCfg.OnResetEffect(null, Target);
            }
        }
    }

    public void Remove()
    {
        Target.Buff.RemoveBuff(Id);
    }
}
