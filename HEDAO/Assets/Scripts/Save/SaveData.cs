using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    public List<PlayerRole> RecruitList = null;
    public Dictionary<long, PlayerRole> RoleDict = new Dictionary<long, PlayerRole>();
    public Dictionary<long, PlayerRole> TeamDict = new Dictionary<long, PlayerRole>();

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