using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameMgr
{
    public static ResManager Res;
    public static CfgManager Cfg;
    public static SaveManager Save;
    public static UIManager UI;
    public static ProcedureManager Procedure;
    public static EntityManager Entity;

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
        Res = CreateManager<ResManager>();
        Cfg = CreateManager<CfgManager>();
        Save = CreateManager<SaveManager>();
        UI = CreateManager<UIManager>();
        Procedure = CreateManager<ProcedureManager>();
        Entity = CreateManager<EntityManager>();
    }

    private static T CreateManager<T>()
        where T : BaseManager, new()
    {
        T manager = new();
        ManagerList.Add(manager);
        return manager;
    }
}
