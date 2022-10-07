using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class MoveCommand : Command
    {
        private Vector2Int m_Start = default;
        private Vector2Int m_End = default;

        public MoveCommand(BattleUnit battleUnit, Vector2Int end) : base(battleUnit)
        {
            m_Start = battleUnit.Data.GridPos;
            m_End = end;
        }

        public override void Execute()
        {
            var gridMap = m_Target.GridMap;
            var start = gridMap.Data.GetGridData(m_Start);
            var end = gridMap.Data.GetGridData(m_End);

            if (end == null || end == start)
            {
                Log.Info("û���ҵ��յ���յ���Ч!");
                return;
            }

            if (GridMapUtl.GetDistance(start, end) > m_Target.Data.MOV)
            {
                Log.Error("�ƶ�������!");
                return;
            }

            start.OnGridUnitLeave();
            end.OnGridUnitEnter(m_Target);
            gridMap.SetGridUnitPos(m_Target, m_End);
        }

        public override void Undo()
        {

        }
    }
}
