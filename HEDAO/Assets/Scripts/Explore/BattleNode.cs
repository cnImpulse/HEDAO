using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleNode : ExploreNode
{
    public BattleNode(int id) : base(id)
    {
    }

    public override void OnSelected()
    {
        GameMgr.Battle.StartBattle(Cfg.BattleId);
    }
}
