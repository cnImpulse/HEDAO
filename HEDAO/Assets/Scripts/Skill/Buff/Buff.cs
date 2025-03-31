using Cfg;
using Cfg.Battle;

public abstract class Buff
{
    public int Id { get; private set; }
    public IEffectTarget Target { get; private set; }
    public BuffCfg Cfg => GameMgr.Cfg.TbBuffCfg.Get(Id);

    public bool IsEffectActive { get; private set; } = false;
    
    public Buff(int id, IEffectTarget target)
    {
        Id = id;
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
}
