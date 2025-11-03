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

    public BattleCfg Cfg => GameMgr.Cfg.TbBattle.Get(CfgId);
    public EResult BattleResult => GetBattleResult();

    private readonly List<Role> LeftUnitList = new List<Role>();
    private readonly List<Role> RightUnitList = new List<Role>();
    public readonly Dictionary<long, Role> BattleUnitDict = new Dictionary<long, Role>();
    public Queue<Role> BattleUnitQueue { get; private set; } = new Queue<Role>();

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
        LeftUnitList.Clear();
        RightUnitList.Clear();
        var list = team.Values.ToList();
        for (int i = 0; i < list.Count; ++i)
        {
            var role = list[i];
            AddBattleUnit(role, true);
        }

        for (int i = 0; i < Cfg.EnemyList.Count; ++i)
        {
            var role = new EnemyRole();
            role.Init(Cfg.EnemyList[i]);
            AddBattleUnit(role, false);
        }
    }

    public void AddBattleUnit(Role role, bool isLeft)
    {
        role.Battle.IsLeft = isLeft;
        role.Battle.TeamList = isLeft ? LeftUnitList : RightUnitList;
        role.Battle.TeamList.Add(role);
        BattleUnitDict.Add(role.Id, role);
    }

    public void RemoveBattleUnit(long id)
    {
        if (BattleUnitDict.TryGetValue(id, out Role role))
        {
            BattleUnitQueue = new Queue<Role>(BattleUnitQueue.Where(e => e.Id != id));
            BattleUnitDict.Remove(id);
            role.Battle.TeamList.Remove(role);
            foreach (var friend in GetRoleList(role.Battle.IsLeft))
            {
                if (friend.Battle.PosIndex > role.Battle.PosIndex)
                {
                    friend.Battle.OnPosChanged?.Invoke();
                }
            }
        }
    }

    public void MoveBattleUnit(Role role, int distance)
    {
        var teamList = role.Battle.TeamList;
        var pos = role.Battle.PosIndex - 1;
        var newIndex = Mathf.Clamp(pos + distance, 0, teamList.Count - 1);
    
        teamList.RemoveAt(pos);
        teamList.Insert(newIndex, role);
    }

    public EResult GetBattleResult()
    {
        if (LeftUnitList.Count == 0)
        {
            return EResult.Win;
        }
        
        if (RightUnitList.Count == 0)
        {
            return EResult.Lose;
        }
        
        return EResult.None;
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

