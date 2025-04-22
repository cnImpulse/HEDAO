using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerData
{
    public int Size = 40;
    public List<ItemData> ItemList;

    public ContainerData()
    {
        ItemList = new List<ItemData>(new ItemData[Size]);
    }

    public void AddItem(ItemData item)
    {
        for (int i = 0; i < ItemList.Count; ++i)
        {
            if (ItemList[i] == null)
            {
                ItemList[i] = item;
                break;
            }
        }
    }

    public void AddItem(int index, ItemData item)
    {
        ItemList[index] = item;
    }

    public void RemoveItem(int index)
    {
        ItemList[index] = null;
    }

    public void RemoveItem(ItemData data)
    {
        if (data == null) return;

        for (int i = 0; i < ItemList.Count; ++i)
        {
            if (ItemList[i] == data)
            {
                ItemList[i] = null;
                break;
            }
        }
    }
}
