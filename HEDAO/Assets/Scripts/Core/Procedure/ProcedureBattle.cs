using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureBattle : FsmState
{
    public BattleData Data => GameMgr.Save.Data.BattleData;
    
    public override void OnEnter()
    {
        base.OnEnter();

        GameMgr.Save.Data.SceneType = SceneType.Battle;
        GameMgr.Battle.LoadBattleMap();
        GameMgr.Battle.InitFsm(Data.BattleState);
        GameMgr.UI.ShowUI(UIName.HudBattle);
    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
