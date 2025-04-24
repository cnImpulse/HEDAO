using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cfg;
using Cfg.Battle;

public class EquipSlot : Container
{
    public Role Owner;

    public EquipSlot(int size, Role owner) : base(size)
    {
        Owner = owner;
    }

    public override void AddItem(ItemData item)
    {
        var equip = item as Equip;
        if (equip == null) return;

        var index = (int)equip.Cfg.EquipType;
        RemoveItem(index);

        item.Throw();

        ItemDict.Add(index, item);
        equip.OnAdd(this);
        equip.OnWear(Owner);
    }

    public override void RemoveItem(ItemData item)
    {
        var equip = item as Equip;
        if (equip == null) return;

        var index = (int)equip.Cfg.EquipType;
        var get = GetItem<Equip>(index);
        if (get != item) return;

        RemoveItem(index);
    }

    public void RemoveItem(int index)
    {
        var item = GetItem<Equip>(index);
        if (item == null) return;

        item.OnRemove();
        item.OnUnWear(Owner);
        ItemDict.Remove(index);
    }

    public T GetItem<T>(int index)
        where T : ItemData
    {
        if (ItemDict.TryGetValue(index, out var item))
        {
            return item as T;
        }

        return null;
    }

    public Equip GetItem(EEquipType type)
    {
        return GetItem<Equip>((int)type);
    }
}
