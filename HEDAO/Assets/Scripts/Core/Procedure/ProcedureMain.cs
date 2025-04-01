using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureMain : FsmState
{
    public override void OnEnter(object data)
    {
        base.OnEnter(data);

        GameMgr.UI.ShowUI(UIName.MenuMain);
    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
