using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureBattle : FsmState
{
    public override void OnEnter()
    {
        base.OnEnter();

    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
