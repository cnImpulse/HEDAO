using Cfg;
using Cfg.Battle;
using UnityEngine;

public class ShieldBuff : Buff
{
    public int MaxDurability = 0;
    public int Durability = 0;
    public new ShieldBuffCfg Cfg => base.Cfg as ShieldBuffCfg;
        
    public ShieldBuff(int id, Role caster, Role target) : base(id, caster, target)
    {
        
    }

    public override void OnAdd()
    {
        MaxDurability = Caster.Attr.SSI;
        Durability = MaxDurability;
    }

    public override void OnRemove()
    {
        
    }

    public int DecDurability(int damage)
    {
        Durability -= damage;
        if (Durability < 0)
        {
            Remove();
            return Mathf.Abs(Durability);
        }

        return 0;
    }
}
