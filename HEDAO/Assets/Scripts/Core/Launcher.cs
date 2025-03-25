using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    void Awake()
    {
        GameMgr.Init();

        GameMgr.Procedure.Fsm.Start(typeof(ProcedureMain));
    }

    private void OnDestroy()
    {
        GameMgr.CleanUp();
    }
}
