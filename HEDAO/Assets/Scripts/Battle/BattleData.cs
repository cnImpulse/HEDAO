using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System.Linq;

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
    public Queue<GridUnit> BattleUnitQueue { get; private set; } = new Queue<GridUnit>();

    [JsonConstructor]
    public BattleData()
    {
    }
    
    public BattleData(int cfgId)
    {
        CfgId = cfgId;
        BattleState = EBattleState.Prepare;

        var cfg = AssetUtl.ReadData<BattleCfg>(AssetUtl.GetBattleCfgPath(CfgId));
        GridMap = new GridMap();
        GridMap.Init(cfg);
    }

    public void OnRemoveBattleUnit(long id)
    {
        GridMap.RemoveGridUnit(id);
        Log.Info(BattleUnitQueue.Count.ToString());
        BattleUnitQueue = new Queue<GridUnit>(BattleUnitQueue.Where(battleUnit => battleUnit.Id != id));
        Log.Info(BattleUnitQueue.Count.ToString());
    }
}

