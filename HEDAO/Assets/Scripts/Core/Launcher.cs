using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    void Awake()
    {
        GameMgr.Init();
        StartCoroutine(InitPackage());
    }

    public IEnumerator InitPackage()
    {
        yield return GameMgr.Res.InitPackage();
        GameMgr.UI.InitPackage();
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
