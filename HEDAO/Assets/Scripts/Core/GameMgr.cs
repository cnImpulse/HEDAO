using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameMgr
{
    public static UIManager UI;
    public static CfgManager Cfg;

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
        Cfg = CreateManager<CfgManager>();
    }

    private static T CreateManager<T>()
        where T : BaseManager, new()
    {
        T manager = new();
        ManagerList.Add(manager);
        return manager;
    }
}
