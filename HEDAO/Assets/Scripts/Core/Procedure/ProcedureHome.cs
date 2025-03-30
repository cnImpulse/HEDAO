using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureHome : FsmState
{
    public override void OnEnter(object data)
    {
        base.OnEnter(data);

        GameMgr.Save.Data.SceneType = SceneType.Home;
        GameMgr.UI.OpenUI(UIName.MenuHome);
    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
