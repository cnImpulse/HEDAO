using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    #region 战斗单位自动行动AI

    // 1. 获取移动前的所有可攻击单元格
    // 2. 选择范围内一个可攻击单位
    // 3. 根据攻击单位寻找移动终点
    // 4. 移动到目标点, 攻击

    #endregion

    public class CommonAI
    {
        private BattleUnit m_Owner = null;

        private GridMap m_GridMap => m_Owner.GridMap;

        public CommonAI(BattleUnit battleUnit)
        {
            m_Owner = battleUnit;
        }

        protected virtual int GetATKRange()
        {
            return 1;
        }

        public void Attack(BattleUnit battleUnit)
        {
            if (battleUnit == null)
            {
                return;
            }

            //battleUnit.Data.HP -= 10;
        }

        public virtual BattleUnit SelectAttackTarget()
        {
            var atkRange = GetATKRange();

            var canAttackList = GetCanAttackGrids(atkRange, m_Owner.Data.MOV);
            var targetCamp = BattleUtl.GetHostileCamp(m_Owner.Data.CampType);
            BattleUnit target = null;
            foreach (var gridData in canAttackList)
            {
                GridUnit gridUnit = gridData.GridUnit;
                if (gridUnit != null && gridUnit is BattleUnit && gridUnit.Data.CampType == targetCamp)
                {
                    var battleUnit = gridUnit as BattleUnit;
                    if (target == null || target.Data.HP < battleUnit.Data.HP)
                    {
                        target = battleUnit;
                    }
                }
            }

            return target;
        }

        public virtual GridData SelectMoveTarget(BattleUnit target)
        {
            if (target == null)
            {
                return null;
            }

            GridData end = null;
            var canMoveList = m_GridMap.Data.GetCanMoveGrids(m_Owner);
            foreach (var gridData in canMoveList)
            {
                int distance = GridMapUtl.GetDistance(target.GridData, gridData);
                int atkRange = GetATKRange();
                if (distance > atkRange)
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
                return m_GridMap.Data.GetRangeGridList(m_Owner.Data.GridPos, atkRange);
            }

            List<GridData> canMoveList = m_GridMap.Data.GetCanMoveGrids(m_Owner);
            List<GridData> canAttackList = new List<GridData>();
            foreach (var gridData in canMoveList)
            {
                var gridList = m_GridMap.Data.GetRangeGridList(gridData.GridPos, atkRange);
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
}