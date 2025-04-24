using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Newtonsoft.Json;

public class ItemData
{
    public int CfgId { get; private set; }
    public Container Owner { get; private set; }

    public ItemCfg Cfg => GameMgr.Cfg.TbItem.Get(CfgId);

    public ItemData(int cfgId)
    {
        CfgId = cfgId;
    }

    public static ItemData CreateItem(int cfgId)
    {
        var cfg = GameMgr.Cfg.TbItem.Get(cfgId);
        if (cfg is EquipCfg)
        {
            return new Equip(cfgId);
        }

        return new ItemData(cfgId);
    }

    public string GetDesc()
    {
        return string.Format("{0}\n---\n{1}", Cfg.Name, SkillUtil.GetEffectDesc(Cfg.EffectList));
    }

    public void OnAdd(Container owner)
    {
        Owner = owner;
    }

    public void OnRemove()
    {
        Owner = null;
    }

    public virtual List<EItemOptionType> GetOptionList()
    {
        var list = new List<EItemOptionType>();
        if (Owner != null)
        {
            list.Add(EItemOptionType.Throw);
        }

        return list;
    }

    public void Throw()
    {
        Owner?.RemoveItem(this);
    }
}
