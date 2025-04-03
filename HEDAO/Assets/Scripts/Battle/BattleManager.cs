using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : BaseManager
{
    public Fsm Fsm { get; private set; }
    public BattleData Data => GameMgr.Save.Data.BattleData;

    public GridUnit CurActionUnit => Data.BattleUnitQueue.Peek();
    public GridMapView GridMapView => GameMgr.Entity.GetEntityView<GridMapView>(Data.GridMap.Id);

    protected override void OnInit()
    {
        base.OnInit();

    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        Fsm?.OnUpdate();
    }

    public void StartBattle(int id)
    {
        GameMgr.Save.Data.BattleData = new BattleData(id);
        GameMgr.Procedure.Fsm.ChangeState<ProcedureBattle>();
    }

    public static Dictionary<EBattleState, Type> BattleStateDict = new Dictionary<EBattleState, Type>()
    {
        [EBattleState.Prepare] = typeof(BattlePrepare), [EBattleState.Start] = typeof(BattleStart), 
        [EBattleState.Loop] = typeof(BattleLoop), [EBattleState.Player] = typeof(BattlePlayer), 
        [EBattleState.AI] = typeof(BattleAI), [EBattleState.End] = typeof(BattleEnd), 
    };
    public void InitFsm(EBattleState state)
    {
        Fsm = Fsm.CreatFsm(this, new BattlePrepare(), new BattleStart(), new BattleLoop(), new BattleEnd(),
            new BattlePlayer(), new BattleAI());
        Fsm.Start(BattleStateDict[state]);
    }
}
