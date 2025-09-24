using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class BuffComponent : Component
{
    public new Role Owner => base.Owner as Role;
    public Dictionary<int, Buff> BuffDict = new Dictionary<int, Buff>();

    protected override void OnInit(object data)
    {
        base.OnInit(data);

    }

    public T GetBuff<T>()
        where T : Buff
    {
        foreach (var buff in BuffDict.Values)
        {
            if (buff is T)
            {
                return buff as T;
            }
        }

        return null;
    }
    
    public void AddBuff(int id, Role caster)
    {
        RemoveBuff(id);

        Buff buff;
        var cfg = GameMgr.Cfg.TbBuffCfg.Get(id);
        if (cfg is ShieldBuffCfg)
        {
            buff = new ShieldBuff(id, caster, Owner);
        }
        else
        {
            buff = new CommonBuff(id, caster, Owner);
        }
        
        BuffDict.Add(id, buff);
        buff.OnAdd();
    }

    public void RemoveBuff(int id)
    {
        if (BuffDict.TryGetValue(id, out var buff))
        {
            buff.OnRemove();
            BuffDict.Remove(id);
        }
    }
}
