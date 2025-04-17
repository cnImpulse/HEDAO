using System;
using System.Collections;
using System.Collections.Generic;
using Cfg.Battle;
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

    public bool PlaySkill(int skillId, GridUnit caster, GridData gridData)
    {
        var target = gridData.GridUnit;
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        if (!IsVaildTarget(skillId, caster, gridData))
        {
            return false;
        }

        var hit = GetHit(skillId, caster, gridData);
        if (!CheckHit(hit))
        {
            var e = new OnTakeEffectEvent()
            {
                Caser = caster,
                Target = target,
                IsMiss = true
            };
            GameMgr.Event.Fire(GameEventType.OnTakeBattleEffect, e);
            
            return true;
        }

        EffectCfg.TakeEffectList(cfg.EffectList, caster, target);
        GameMgr.Entity.GetEntityView<GridUnitView>(caster.Id).PlayAttackAnim(gridData);

        return true;
    }

    public bool IsVaildTarget(int skillId, GridUnit caster, GridData gridData)
    {
        if (gridData == null) return false;

        var target = gridData.GridUnit;
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        if (cfg.TargetType != Cfg.ERelationType.Self && target == null)
        {
            return false;
        }

        if (cfg.TargetType != BattleUtil.GetRelationType(caster, target))
        {
            return false;
        }

        return true;
    }

    public int GetHit(int skillId, GridUnit caster, GridData gridData)
    {
        var target = gridData.GridUnit;
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        var hit = cfg.Hit;
        if (cfg.TargetType == Cfg.ERelationType.Enemy)
        {
            hit -= target.Role.Attr.SEF;
        }

        return Mathf.Clamp(hit, GameMgr.Cfg.TbMisc.MinHit, 100);
    }

    public bool CheckHit(int hit)
    {
        hit = Mathf.Clamp(hit, 0, 100);
        var random = UnityEngine.Random.Range(0, 100);
        return random < hit;
    }
}
