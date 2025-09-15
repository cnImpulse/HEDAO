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

    public Dictionary<long, Role> BattleUnitDict = new Dictionary<long, Role>();
    public Queue<Role> BattleUnitQueue { get; private set; } = new Queue<Role>();

    public BattleCfg Cfg => GameMgr.Cfg.TbBattle.Get(CfgId);
    public EResult BattleResult => GetBattleResult();


    [JsonConstructor]
    public BattleData()
    {
    }
    
    public BattleData(int cfgId, Dictionary<long, PlayerRole> team)
    {
        CfgId = cfgId;
        BattleState = EBattleState.Prepare;

        InitBattleUnit(team);
    }
    
    private void InitBattleUnit(Dictionary<long, PlayerRole> team)
    {
        var list = team.Values.ToList();
        for (int i = 0; i < list.Count; ++i)
        {
            var role = list[i];
            role.Battle.PosIndex = i + 1;
            role.Battle.IsLeft = true;
            BattleUnitDict.Add(role.Id, role);
        }

        for (int i = 0; i < Cfg.EnemyList.Count; ++i)
        {
            var role = new EnemyRole();
            role.Init(Cfg.EnemyList[i]);
            role.Battle.PosIndex = i + 1;
            role.Battle.IsLeft = false;
            BattleUnitDict.Add(role.Id, role);
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

    public Role GetRole(int pos, bool isLeft)
    {
        foreach(var role in BattleUnitDict.Values)
        {
            if (role.Battle.PosIndex == pos)
            {
                return role;
            }
        }

        return null;
    }
    
    public List<Role> GetRoleList(bool isLeft)
    {
        var list = new List<Role>();
        foreach(var role in BattleUnitDict.Values)
        {
            if (role.Battle.IsLeft == isLeft)
            {
                list.Add(role);
            }
        }

        return list;
    }

    public List<Role> GetRoleList(List<int> targetPos, bool isLeft)
    {
        var list = BattleUnitDict.Values.Where(role => role.Battle.IsLeft == isLeft && targetPos.Contains(role.Battle.PosIndex)).ToList();
        return list;
    }
}

