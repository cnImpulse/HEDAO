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
        Data.Init();

        foreach (var role in Data.Team.Values)
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
        if (count == 0) return EResult.Lose;
        if (Data.ExploreQueue.Count == 0) return EResult.Win;

        return EResult.None;
    }

    public void CreateMap()
    {
        GameMgr.Res.LoadAsset<GameObject>(10008);
    }
}
