using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class EquipComponent : Component
{
    public new Role Owner => base.Owner as Role;
    public Dictionary<EEquipType, ItemData> EquipDict = new Dictionary<EEquipType, ItemData>();

    protected override void OnInit(object data)
    {
        base.OnInit(data);

        foreach (var pair in Owner.InitCfg.InitEquip)
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
