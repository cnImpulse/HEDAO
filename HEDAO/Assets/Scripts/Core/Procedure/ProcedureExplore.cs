using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureExplore : FsmState
{
    public override void OnEnter(object data)
    {
        base.OnEnter(data);

        GameMgr.Save.Data.SceneType = SceneType.Explore;
        GameMgr.UI.OpenUI(UIName.MenuExplore);
    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
