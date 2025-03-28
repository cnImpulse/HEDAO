using Cfg;
using Cfg.Battle;

public class Buff
{
    public int Id { get; private set; }
    public int Life { get; private set; }
    public IEffectTarget Target { get; private set; }
    public BuffCfg Cfg => GameMgr.Cfg.Tables.TbBuffCfg.Get(Id);
        
    public Buff(int id, IEffectTarget target)
    {
        Id = id;
        Target = target;
    }

    public virtual void OnAdd()
    {
        var cfg = GameMgr.Cfg.Tables.TbBuffCfg.Get(Id);

    }

    public virtual void OnRoundStart()
    {

    }

    public virtual void OnRemove()
    {
    }
}
