using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cfg.Battle;
using UnityEngine;

public class BattleManager : BaseManager
{
    public Fsm Fsm { get; private set; }
    public BattleData Data => GameMgr.Save.Data.BattleData;
    public BattleMapView BattleMapView;

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

    public void EndBattle()
    {
        GameMgr.Procedure.Fsm.ChangeState<ProcedureExplore>();
        GameMgr.Save.Data.BattleData = null;
    }

    public void LoadBattleMap()
    {
        BattleMapView = GameMgr.Res.LoadAsset<GameObject>(10001).GetComponent<BattleMapView>();
    }

    public static Dictionary<EBattleState, Type> BattleStateDict = new Dictionary<EBattleState, Type>()
    {
        [EBattleState.Prepare] = typeof(BattlePrepare),
        [EBattleState.Start] = typeof(BattleStart),
        [EBattleState.Loop] = typeof(BattleLoop),
        [EBattleState.Player] = typeof(BattlePlayer),
        [EBattleState.AI] = typeof(BattleAI),
        [EBattleState.End] = typeof(BattleEnd),
    };
    public void InitFsm(EBattleState state)
    {
        Fsm = Fsm.CreatFsm(this, new BattlePrepare(), new BattleStart(), new BattleLoop(), new BattleEnd(),
            new BattlePlayer(), new BattleAI());
        Fsm.Start(BattleStateDict[state]);
    }

    //public void PlaySkill(int skillId, GridUnit caster, GridUnit target)
    //{

    //}

    //public int GetHit(int skillId, GridUnit caster, GridUnit target)
    //{
    //    var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
    //    var hit = cfg.Hit;
    //    if (cfg.TargetType == Cfg.ERelationType.Enemy)
    //    {
    //        hit -= target.Role.Attr.SEF;
    //    }

    //    return Mathf.Clamp(hit, GameMgr.Cfg.TbMisc.MinHit, 100);
    //}

    public bool CheckHit(int hit)
    {
        hit = Mathf.Clamp(hit, 0, 100);
        var random = UnityEngine.Random.Range(0, 100);
        return random < hit;
    }
}
