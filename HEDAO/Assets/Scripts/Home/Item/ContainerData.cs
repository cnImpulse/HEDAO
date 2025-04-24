using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container
{
    public int Size = 1;
    public Dictionary<int, ItemData> ItemDict = new Dictionary<int, ItemData>();

    public Container(int size)
    {
        Size = size;
    }

    public virtual void AddItem(ItemData item)
    {
    }

    public virtual void RemoveItem(ItemData item)
    {
        
    }

    public List<ItemData> GetDataList()
    {
        var dataList = new List<ItemData>(new ItemData[Size]);
        foreach(var pair in ItemDict)
        {
            dataList[pair.Key] = pair.Value;
        }

        return dataList;
    }
}
