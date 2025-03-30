using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreManager : BaseManager
{
    public ExploreDate Data => GameMgr.Save.Data.ExploreDate;

    protected override void OnInit()
    {
        base.OnInit();

    }

    public void StartExplore()
    {
        GameMgr.Save.Data.ExploreDate = new ExploreDate();

        foreach (var id in GameMgr.Save.Data.RoleTeamSet)
        {
            var role = GameMgr.Save.Data.DiscipleList[id];
            role.ResetBattleState();
        }

        GameMgr.Procedure.Fsm.ChangeState<ProcedureExplore>();
    }
}
