using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeData
{
    public Container Store;

    public static HomeData Create()
    {
        var data = new HomeData();
        data.Store = new Store(40);
        data.Store.AddItem(new ItemData(10004));
        return data;
    }
}
