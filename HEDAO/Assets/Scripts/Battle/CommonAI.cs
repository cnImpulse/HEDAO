using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region 战斗单位自动行动AI

// 1. 获取移动前的所有可攻击单元格
// 2. 选择范围内一个可攻击单位
// 3. 根据攻击单位寻找移动终点
// 4. 移动到目标点, 攻击

#endregion

public class CommonAI
{
    public GridUnit Owner { get; private set; }
    public int MaxATKRange { get; private set; }

    public GridMap BattleMap => GameMgr.Battle.Data.GridMap;

    public CommonAI()
    {
    }

    public CommonAI(GridUnit battleUnit)
    {
        Owner = battleUnit;

        foreach (var skillId in Owner.Role.SkillSet)
        {
            var skillCfg = GameMgr.Cfg.TbSkill.GetOrDefault(skillId);
            MaxATKRange = Mathf.Max(MaxATKRange, skillCfg.ReleaseRange.Distance);
        }
    }

    public void Attack(GridUnit battleUnit)
    {
        if (battleUnit == null)
        {
            return;
        }

        foreach(var skillId in Owner.Role.SkillSet)
        {
            var success = GameMgr.Battle.PlaySkill(skillId, Owner, battleUnit.GridData);
            if (success)
            {
                break;
            }
        }
    }

    public virtual GridUnit SelectAttackTarget()
    {
        var canAttackList = GetCanAttackGrids(MaxATKRange, Owner.MOV);
        var targetCamp = BattleUtil.GetHostileCamp(Owner.CampType);
        GridUnit target = null;
        foreach (var gridData in canAttackList)
        {
            GridUnit gridUnit = gridData.GridUnit;
            if (gridUnit != null && gridUnit is GridUnit && gridUnit.CampType == targetCamp)
            {
                var battleUnit = gridUnit as GridUnit;
                if (target == null || target.HP > battleUnit.HP)
                {
                    target = battleUnit;
                }
            }
        }

        return target;
    }

    public virtual GridData SelectMoveTarget(GridUnit target)
    {
        if (target == null)
        {
            return null;
        }

        GridData end = null;
        var canMoveList = BattleMap.GetCanMoveGrids(Owner, Owner.MOV);
        foreach (var gridData in canMoveList)
        {
            int distance = GridMapUtl.GetDistance(target.GridData, gridData);
            if (distance > MaxATKRange)
            {
                continue;
            }

            if (end == null || GridMapUtl.GetDistance(target.GridData, end) < distance)
            {
                end = gridData;
            }
        }

        return end;
    }

    private List<GridData> GetCanAttackGrids(int atkRange, int mov)
    {
        if (mov <= 0)
        {
            return BattleMap.GetRangeGridList(Owner.GridPos, atkRange);
        }

        List<GridData> canMoveList = BattleMap.GetCanMoveGrids(Owner, Owner.MOV);
        List<GridData> canAttackList = new List<GridData>();
        foreach (var gridData in canMoveList)
        {
            var gridList = BattleMap.GetRangeGridList(gridData.GridPos, atkRange);
            foreach (var grid in gridList)
            {
                if (canAttackList.Contains(grid))
                {
                    continue;
                }

                canAttackList.Add(grid);
            }
        }

        return canAttackList;
    }
}