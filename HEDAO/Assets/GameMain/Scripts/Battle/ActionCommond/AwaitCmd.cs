using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class AwaitCmd : Command
    {
        public AwaitCmd(BattleUnit battleUnit) : base(battleUnit)
        {
        }

        public override void Redo()
        {
            Owner.OnEndAction();
        }

        public override void Undo()
        {
            Owner.CanAction = true;
        }
    }
}
