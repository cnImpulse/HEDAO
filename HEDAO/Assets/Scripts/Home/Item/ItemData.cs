using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class ItemData
{
    public int CfgId { get; private set; }
    public Container Owner { get; private set; }

    public ItemCfg Cfg => GameMgr.Cfg.TbItem.Get(CfgId);

    public ItemData(int cfgId)
    {
        CfgId = cfgId;
    }

    public string GetDesc()
    {
        return string.Format("{0}\n---\n{1}", Cfg.Name, SkillUtil.GetEffectDesc(Cfg.EffectList));
    }

    private static List<EItemOptionType> s_OptionList = new List<EItemOptionType> { EItemOptionType.Equip, EItemOptionType.Throw };
    public List<EItemOptionType> GetOptionList()
    {
        return s_OptionList;
    }

    public void OnAdd(Container owner)
    {
        Owner = owner;
    }

    public void OnRemove(Container owner)
    {
        Owner = owner;
    }
}
