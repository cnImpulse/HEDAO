using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureBattle : FsmState
{
    public override void OnEnter(object data)
    {
        base.OnEnter(data);

        GameMgr.Save.Data.SceneType = SceneType.Battle;
    }

    public override void OnLeave()
    {
        GameMgr.UI.CloseAllUI();

        base.OnLeave();
    }
}
