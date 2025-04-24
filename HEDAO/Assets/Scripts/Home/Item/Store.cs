using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : Container
{
    public Store(int size) : base(size)
    {
    }

    public override void AddItem(ItemData item)
    {
        if (item == null) return;

        for (int i = 0; i < Size; ++i)
        {
            if (ItemDict.TryAdd(i, item))
            {
                item.Throw();
                item.OnAdd(this);
                break;
            }
        }
    }

    public override void RemoveItem(ItemData item)
    {
        if (item == null) return;

        for (int i = 0; i < Size; ++i)
        {
            if (ItemDict.ContainsKey(i) && ItemDict[i] == item)
            {
                item.OnRemove();
                ItemDict.Remove(i);
                break;
            }
        }
    }
}
