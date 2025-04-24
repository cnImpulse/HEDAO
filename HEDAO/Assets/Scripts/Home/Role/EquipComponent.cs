using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class EquipComponent : Component
{
    public new Role Owner => base.Owner as Role;
    public Dictionary<EEquipType, Equip> EquipDict = new Dictionary<EEquipType, Equip>();

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        foreach (var pair in Owner.InitCfg.InitEquip)
        {
            AddEquip(new Equip(pair.Value));
        }
    }

    public ItemData GetEquip(EEquipType type)
    {
        if (EquipDict.TryGetValue(type, out var item))
        {
            return item;
        }

        return null;
    }

    public void AddEquip(Equip data)
    {
        EquipCfg cfg = data.Cfg;
        if (EquipDict.ContainsKey(cfg.EquipType))
        {
            var result = RemoveEquip(cfg.EquipType);
            if (!result) return;
        }

        EquipDict.Add(cfg.EquipType, data);
        data.OnWear(Owner);
    }

    public bool RemoveEquip(EEquipType type)
    {
        if (!EquipDict.ContainsKey(type))
        {
            return false;
        }

        EquipDict[type].OnUnWear(Owner);
        EquipDict.Remove(type);

        return true;
    }
}
