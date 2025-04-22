using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class EquipComponent
{
    public Role Owner;
    public Dictionary<EEquipType, ItemData> EquipDict = new Dictionary<EEquipType, ItemData>();

    public void Init(Role role)
    {
        Owner = role;
        foreach(var pair in role.InitCfg.InitEquip)
        {
            AddEquip(new ItemData(pair.Value));
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

    public void AddEquip(ItemData data)
    {
        EquipCfg cfg = data.Cfg as EquipCfg;
        if (EquipDict.ContainsKey(cfg.EquipType))
        {
            var result = RemoveEquip(cfg.EquipType);
            if (!result) return;
        }

        EquipDict.Add(cfg.EquipType, data);
        EffectCfg.TakeEffectList(data.Cfg.EffectList, null, Owner);
    }

    public bool RemoveEquip(EEquipType type)
    {
        if (!EquipDict.ContainsKey(type))
        {
            return false;
        }

        EffectCfg.ResetEffectList(EquipDict[type].Cfg.EffectList, null, Owner);
        EquipDict.Remove(type);

        return true;
    }
}
