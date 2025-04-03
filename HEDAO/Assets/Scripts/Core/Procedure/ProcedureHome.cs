using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureHome : FsmState
{
    public override void OnEnter()
    {
        base.OnEnter();

        GameMgr.Save.Data.SceneType = SceneType.Home;
        GameMgr.UI.ShowUI(UIName.MenuHome);
    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
