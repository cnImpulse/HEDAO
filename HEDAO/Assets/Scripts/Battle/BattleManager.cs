using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseManager
{
    public BattleData Data => GameMgr.Save.Data.BattleData;

    protected override void OnInit()
    {
        base.OnInit();

    }

    public void StartBattle(int id)
    {
        GameMgr.Save.Data.BattleData = new BattleData();
        GameMgr.Procedure.Fsm.ChangeState<ProcedureBattle>();
    }

    protected void CreatBattleMap(int id)
    {

    }

    protected void AddGridUnit()
    {

    }

    public void EndBattle(int id)
    {

    }
}
