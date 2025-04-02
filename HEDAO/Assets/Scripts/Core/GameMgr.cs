using System;
using System.Collections;
using System.Collections.Generic;
using Cfg;

public static class GameMgr
{
    public static ResManager Res;
    public static CfgManager Cfg;
    public static SaveManager Save;
    public static UIManager UI;
    public static ProcedureManager Procedure;
    public static EntityManager Entity;
    public static BattleManager Battle;
    public static ExploreManager Explore;

    // 纯表现
    public static EffectManager Effect;

    private static List<BaseManager> ManagerList = new List<BaseManager>();

    public static void Init()
    {
        CreateManagers();

        foreach(var mgr in ManagerList)
        {
            mgr.Init();
        }
    }

    public static void CleanUp()
    {
        foreach (var mgr in ManagerList)
        {
            mgr.CleanUp();
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
        Battle = CreateManager<BattleManager>();
        Explore = CreateManager<ExploreManager>();

        Effect = CreateManager<EffectManager>();
    }

    private static T CreateManager<T>()
        where T : BaseManager, new()
    {
        T manager = new();
        ManagerList.Add(manager);
        return manager;
    }

    public static void Update()
    {
        foreach (var mgr in ManagerList)
        {
            mgr.OnUpdate();
        }
    }
}
