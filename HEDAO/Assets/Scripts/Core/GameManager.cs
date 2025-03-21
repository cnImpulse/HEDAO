using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static UIManager UI;

    private static List<BaseManager> ManagerList = new List<BaseManager>();

    public static void Init()
    {
        CreateManagers();

        foreach(var mgr in ManagerList)
        {
            mgr.Init();
        }
    }

    public static void CreateManagers()
    {
        UI = CreateManager<UIManager>();
    }

    private static T CreateManager<T>()
        where T : BaseManager, new()
    {
        T manager = new();
        ManagerList.Add(manager);
        return manager;
    }
}
