using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureExplore : FsmState
{
    public override void OnEnter()
    {
        base.OnEnter();

        GameMgr.Save.Data.SceneType = SceneType.Explore;
        GameMgr.UI.ShowUI(UIName.MenuExplore);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (GameMgr.Explore.GetExploreResult() != EResult.None)
        {
            ChangeState<ProcedureHome>();
        }
    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
