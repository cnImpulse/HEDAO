using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public List<Role> RandomRoleList = null;
    public Dictionary<long, Role> RoleDict = new Dictionary<long, Role>();
    public Dictionary<long, Role> TeamDict = new Dictionary<long, Role>();

    public int Year = 1;
    public SceneType SceneType = SceneType.Home;
    public ExploreDate ExploreDate;
    public BattleData BattleData;

    public SaveData()
    {

    }

    public void Init()
    {
    }
}

public enum SceneType
{
    Home,
    Explore,
    Battle
}