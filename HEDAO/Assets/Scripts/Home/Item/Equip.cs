using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class Equip : ItemData
{
    public new EquipCfg Cfg => base.Cfg as EquipCfg;

    public Equip(int cfgId) : base(cfgId)
    {
    }

    public void OnWear(Role owner)
    {
        EffectCfg.TakeEffectList(Cfg.EffectList, null, owner);
    }

    public void OnUnWear(Role owner)
    {
        EffectCfg.ResetEffectList(Cfg.EffectList, null, owner);
    }

    public override List<EItemOptionType> GetOptionList()
    {
        var list = base.GetOptionList();
        if (Owner is Store)
        {
            list.Add(EItemOptionType.Wear);
        }
        else
        {
            list.Clear();
            if (Owner is EquipSlot)
            {
                list.Add(EItemOptionType.UnWear);
            }
        }

        return list;
    }
}
