using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    void Awake()
    {
        GameMgr.Init();
        StartCoroutine(GameMgr.Res.InitPackage());
        GameMgr.Procedure.Fsm.Start<ProcedureMain>();
    }

    private void Update()
    {
        GameMgr.Update();
    }

    private void OnDestroy()
    {
        GameMgr.CleanUp();
    }
}
