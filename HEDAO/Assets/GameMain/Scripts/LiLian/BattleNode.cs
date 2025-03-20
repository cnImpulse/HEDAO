using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class BattleNode : ActionNodeBase
    {
        public BattleNode(int cfgId) : base(cfgId)
        {
        }

        protected override void OnAction()
        {
            base.OnAction();

            GameEntry.Event.Fire(this, EventName.StartBattle, 2);
        }
    }
}