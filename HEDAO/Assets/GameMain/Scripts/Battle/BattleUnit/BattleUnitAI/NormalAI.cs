using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class NormalAI : IBattleUnitAI
    {
        private BattleUnit m_Owner = null;

        private GridMap GridMap => m_Owner.GridMap;

        public NormalAI(BattleUnit battleUnit)
        {
            m_Owner = battleUnit;
        }

        public BattleUnit SelectAttackTarget()
        {
            var canAttackList = GridMap.Data.GetCanAttackGrids(m_Owner, 3, 3, true);
            var targetCamp = BattleUtl.GetHostileCamp(m_Owner.Data.CampType);
            foreach (var gridData in canAttackList)
            {
                GridUnit gridUnit = gridData.GridUnit;
                if (gridUnit != null && gridUnit is BattleUnit && gridUnit.Data.CampType == targetCamp)
                {
                    return gridUnit as BattleUnit;
                }
            }

            return null;
        }

        public Vector2Int SelectMoveTarget()
        {
            //if (attackTarget == null)
            //{
            //    return null;
            //}

            //GridData end = null;
            //var canMoveList = GridMap.Data.GetCanMoveGrids(m_Owner, 3);
            //foreach (var gridData in canMoveList)
            //{
            //    int distance = GridMapUtl.GetDistance(attackTarget.GridData, gridData);
            //    int atkRange = skillCfg.ReleaseRange;
            //    if (distance > atkRange)
            //    {
            //        continue;
            //    }

            //    if (end == null)
            //    {
            //        end = gridData;
            //        continue;
            //    }

            //    int tempDis = GridMapUtl.GetDistance(attackTarget.GridData, end);
            //    if (tempDis < distance)
            //    {
            //        end = gridData;
            //    }
            //}

            //return end;
            return default;
        }
    }
}