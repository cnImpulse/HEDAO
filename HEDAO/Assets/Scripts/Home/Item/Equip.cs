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
}
