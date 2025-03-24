using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureMain : FsmState
{
    public override void OnEnter()
    {
        base.OnEnter();

        GameMgr.UI.OpenUI(UIName.MenuMain);
    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
