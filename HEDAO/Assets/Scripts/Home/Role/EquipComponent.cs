using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class EquipComponent : Component
{
    public new Role Owner => base.Owner as Role;
    public EquipSlot Slot;

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        Slot = new EquipSlot(3, Owner);
        foreach (var pair in Owner.InitCfg.InitEquip)
        {
            Slot.AddItem(new Equip(pair.Value));
        }
    }
}
