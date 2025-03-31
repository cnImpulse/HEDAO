using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    void Awake()
    {
        GameMgr.Init();
        StartCoroutine(GameMgr.Res.InitPackage());
        GameMgr.Procedure.Fsm.Start(typeof(ProcedureMain));
    }

    private void OnDestroy()
    {
        GameMgr.CleanUp();
    }
}
