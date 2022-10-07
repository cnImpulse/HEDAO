using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public abstract class Command
    {
        protected BattleUnit m_Target = null;

        public Command(BattleUnit battleUnit)
        {
            m_Target = battleUnit;
        }

        public virtual void Execute()
        {

        }

        public virtual void Undo()
        {

        }
    }
}
