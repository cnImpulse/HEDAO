using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using System.Linq;
using Cfg;

public enum EBattleState
{
    Prepare,
    Start,
    Loop,
    Player,
    AI,
    End
}

public enum EResult
{
    None,
    [EnumName("胜利")]
    Win,
    [EnumName("失败")]
    Lose,
}

public class BattleData
{
    public int CfgId { get; private set; }
    public EBattleState BattleState { get; private set; }
    public List<Role> PlayerTeam = new List<Role>();
    public List<Role> EnemyTeam = new List<Role>();
    //public Queue<GridUnit> BattleUnitQueue { get; private set; } = new Queue<GridUnit>();

    public BattleCfg Cfg => GameMgr.Cfg.TbBattle.Get(CfgId);
    public EResult BattleResult => GetBattleResult();


    [JsonConstructor]
    public BattleData()
    {
    }
    
    public BattleData(int cfgId)
    {
        CfgId = cfgId;
        BattleState = EBattleState.Prepare;

        InitBattleUnit();
    }

    private void InitBattleUnit()
    {
        foreach (var role in GameMgr.Explore.Data.Team.Values)
        {
            PlayerTeam.Add(role);
        }

        foreach(var id in Cfg.EnemyList)
        {
            var role = new EnemyRole();
            role.Init(id);
            EnemyTeam.Add(role);
        }
    }

    public void OnRemoveBattleUnit(long id)
    {
        //BattleUnitQueue = new Queue<GridUnit>(BattleUnitQueue.Where(battleUnit => battleUnit.Id != id));
    }

    public EResult GetBattleResult()
    {

        return EResult.None;
    }
}

