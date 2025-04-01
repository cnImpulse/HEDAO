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

        foreach (var role in GameMgr.Save.Data.TeamDict.Values)
        {
            role.Attr.OnStartExplore();
        }

        GameMgr.Procedure.Fsm.ChangeState<ProcedureExplore>();
    }
}
