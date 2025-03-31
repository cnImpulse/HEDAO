using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureBattle : FsmState
{
    public BattleData Data => GameMgr.Save.Data.BattleData;
    
    public override void OnEnter(object data)
    {
        base.OnEnter(data);

        GameMgr.Save.Data.SceneType = SceneType.Battle;
        GameMgr.Entity.ShowEntity<GridMapView>(Data.GridMap);
    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
