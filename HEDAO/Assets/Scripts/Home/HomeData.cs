using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeData
{
    public Store Store;

    public static HomeData Create()
    {
        var data = new HomeData();
        data.Store = new Store(40);
        data.Store.AddItem(ItemData.CreateItem(10004));
        return data;
    }
}
