using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cfg.Battle;
using DG.Tweening;
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
        GameMgr.Save.Data.BattleData = new BattleData(id, GameMgr.Explore.Data.Team);
        GameMgr.Procedure.Fsm.ChangeState<ProcedureBattle>();
    }
    
    public void StartBattle(int id, Dictionary<long, PlayerRole> team)
    {
        GameMgr.Save.Data.BattleData = new BattleData(id, team);
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

    public bool PlaySkill(int skillId, Role caster, Role target)
    {
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        var hit = SkillUtil.GetHit(skillId, caster, target);
        
        var casterView = GameMgr.Entity.GetEntityView<BattleUnitView>(caster.Id);
        var targetView = GameMgr.Entity.GetEntityView<BattleUnitView>(target.Id);
        targetView.PlaySpineAnim("defend");
        casterView.PlaySpineAnim("attack", () =>
        {
            if (!CheckHit(hit))
            {
                GameMgr.UI.ShowFloatUI(UIName.FloatBubble, new BubbleData {Text = "未命中", TargetId = target.Id});
                GameMgr.Event.Fire(GameEventType.OnBattleUnitActionEnd);
                return;
            }

            foreach(var effectId in cfg.EffectList)
            {
                var effectCfg = GameMgr.Cfg.TbEffectCfg.Get(effectId);
                var result = effectCfg.OnTakeEffect(caster, target);
                if (result != null)
                {
                    GameMgr.UI.ShowFloatUI(UIName.FloatBubble, new BubbleData {Damage = result.Damage, TargetId = target.Id});
                }
            }
            
            if (target.Battle.IsDead)
            {
                targetView.PlayDeadAnim(() =>
                {
                    Data.RemoveBattleUnit(target.Id);
                    GameMgr.Entity.HideEntity(target.Id);
                    
                    DOVirtual.DelayedCall(0.5f, () =>
                    {
                        GameMgr.Event.Fire(GameEventType.OnBattleUnitActionEnd);
                    });
                });
            }
            else
            {
                GameMgr.Event.Fire(GameEventType.OnBattleUnitActionEnd);
            }
        });
        
        return true;
    }

    public bool CheckHit(int hit)
    {
        hit = Mathf.Clamp(hit, 0, 100);
        var random = UnityEngine.Random.Range(0, 100);
        return random < hit;
    }
}
