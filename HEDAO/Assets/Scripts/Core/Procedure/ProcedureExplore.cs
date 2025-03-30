using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureExplore : FsmState
{
    public override void OnEnter()
    {
        base.OnEnter();

        foreach (var id in GameMgr.Save.Data.RoleTeamSet)
        {
            var role = GameMgr.Save.Data.DiscipleList[id];
            role.ResetBattleState();
        }

        GameMgr.UI.OpenUI(UIName.MenuExplore);
    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
