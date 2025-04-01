using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public enum EBattleState
{
    Prepare,
    Start,
    Loop,
    Player,
    AI,
    End
}

public class BattleData
{
    public int CfgId { get; private set; }
    public EBattleState BattleState { get; private set; }
    public GridMap GridMap { get; private set; }

    [JsonConstructor]
    public BattleData()
    {
    }
    
    public BattleData(int cfgId)
    {
        CfgId = cfgId;
        BattleState = EBattleState.Prepare;
        GridMap = new GridMap(1);
        GridMap.Init();
    }
}

