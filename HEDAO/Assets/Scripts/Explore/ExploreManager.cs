using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void EndExplore()
    {
        GameMgr.Procedure.Fsm.ChangeState<ProcedureHome>();
        GameMgr.Save.Data.ExploreDate = null;
    }

    public EResult GetExploreResult()
    {
        var count = GameMgr.Save.Data.TeamDict.Values.Where(role => role.Attr.HP > 0).Count();
        return count > 0 ? EResult.None : EResult.Lose;
    }
}
