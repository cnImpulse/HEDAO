using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedureManager : BaseManager
{
    public Fsm Fsm;

    protected override void OnInit()
    {
        Fsm = Fsm.CreatFsm(new ProcedureMain(), new ProcedureHome(), new ProcedureExplore(), new ProcedureBattle());
    }
}
