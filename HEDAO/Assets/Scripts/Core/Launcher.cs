using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMod
{
    Editor,
    Offline
}

public class Launcher : MonoBehaviour
{
    public GameMod GameMod = GameMod.Editor;
    
    void Awake()
    {
        Application.targetFrameRate = 60;
        StartCoroutine(InitPackage());
    }

    public IEnumerator InitPackage()
    {
        GameMgr.InitPre();

        if (Application.isEditor && GameMod == GameMod.Editor)
        {
            yield return GameMgr.Res.InitPackage();
        }
        else
        {
            yield return GameMgr.Res.InitPackageRuntime();
        }
        
        GameMgr.Init();
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
