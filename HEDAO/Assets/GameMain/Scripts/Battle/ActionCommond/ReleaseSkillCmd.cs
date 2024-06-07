using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class ReleaseSkillCmd : Command
    {

        public ReleaseSkillCmd(BattleUnit battleUnit) : base(battleUnit)
        {
        }

        public override void Redo()
        {
        }

        public override void Undo()
        {
        }
    }
}
