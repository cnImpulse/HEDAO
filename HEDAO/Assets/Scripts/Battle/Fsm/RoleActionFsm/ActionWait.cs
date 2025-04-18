using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWait : ActionStateBase
{
    public override void OnEnter()
    {
        base.OnEnter();

        Owner.Req.ReqActionList.Add(new ReqWait());
        Owner.Close();
        GameMgr.Battle.ReqBattleUnitAction(Owner.Req);
    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
}
