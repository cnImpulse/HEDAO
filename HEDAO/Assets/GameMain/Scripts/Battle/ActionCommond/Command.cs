using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public abstract class Command
    {
        public BattleUnit Owner = null;

        public Command(BattleUnit battleUnit)
        {
            Owner = battleUnit;
        }

        public virtual void Redo()
        {

        }

        public virtual void Undo()
        {

        }
    }
}
