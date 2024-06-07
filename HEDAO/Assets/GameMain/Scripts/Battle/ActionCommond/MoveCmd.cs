using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class MoveCmd : Command
    {
        private Vector2Int m_Start = default;
        private Vector2Int m_End = default;

        public MoveCmd(BattleUnit battleUnit, Vector2Int end) : base(battleUnit)
        {
            m_Start = battleUnit.Data.GridPos;
            m_End = end;
        }

        public override void Redo()
        {
            Owner.Move(m_End);
        }

        public override void Undo()
        {
            Owner.Move(m_Start);
        }
    }
}
