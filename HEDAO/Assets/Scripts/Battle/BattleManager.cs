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

    public class SkillResult
    {
        public Role Caster;
        public List<Role> TargetList;
        public List<Role> MissList = new List<Role>();
        public Dictionary<Role, List<TakeEffectResult>> EffectResult = new Dictionary<Role, List<TakeEffectResult>>();
    }
    
    public void PlaySkill(int skillId, Role caster, Role target)
    {
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        var hit = SkillUtil.GetHit(skillId, caster, target);

        SkillResult skillResult = new SkillResult();
        List<Role> targetList = GetSkillTargetList(skillId, caster, target);
        
        skillResult.Caster = caster;
        skillResult.TargetList = targetList;
        foreach (var enemy in targetList)
        {
            if (!CheckHit(hit))
            {
                skillResult.MissList.Add(enemy);
                continue;
            }

            var effectResult = new List<TakeEffectResult>();
            skillResult.EffectResult.Add(enemy, effectResult);
            foreach(var effectId in cfg.EffectList)
            {
                var effectCfg = GameMgr.Cfg.TbEffectCfg.Get(effectId);
                var result = effectCfg.OnTakeEffect(caster, enemy);
                if (result != null)
                {
                    effectResult.Add(result);
                }
            }
        }

        PlaySkillSpineAnim(skillResult);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(DOVirtual.DelayedCall(1.2f, () =>
        {
            foreach (var enemy in skillResult.MissList)
            {
                GameMgr.UI.ShowFloatUI(UIName.FloatBubble, new BubbleData {Text = "未命中", TargetId = enemy.Id});
            }

            foreach (var pair in skillResult.EffectResult)
            {
                var enemy = pair.Key;
                foreach (var effectResult in pair.Value)
                {
                    GameMgr.UI.ShowFloatUI(UIName.FloatBubble, new BubbleData {Damage = effectResult.Damage, TargetId = enemy.Id});
                }
            }
        }));

        bool isAppend = true;
        foreach (var pair in skillResult.EffectResult)
        {
            var enemy = pair.Key;
            if (enemy.Battle.IsDead)
            {
                var targetView = GameMgr.Entity.GetEntityView<BattleUnitView>(enemy.Id);
                if (isAppend)
                {
                    isAppend = false;
                    sequence.Append(targetView.PlayDeadAnim(() =>
                    {
                        Data.RemoveBattleUnit(enemy.Id);
                        GameMgr.Entity.HideEntity(enemy.Id);
                    }));   
                }
                else
                {
                    sequence.Join(targetView.PlayDeadAnim(() =>
                    {
                        Data.RemoveBattleUnit(enemy.Id);
                        GameMgr.Entity.HideEntity(enemy.Id);
                    }));   
                }
            }
        }

        sequence.Append(DOVirtual.DelayedCall(0.3f, () =>
        {
            GameMgr.Event.Fire(GameEventType.OnBattleUnitActionEnd);
        }));
        sequence.SetAutoKill(true);
    }

    private void PlaySkillSpineAnim(SkillResult result)
    {
        var caster = result.Caster;
        var targetList = result.TargetList;
        
        var casterView = GameMgr.Entity.GetEntityView<BattleUnitView>(caster.Id);
        casterView.PlaySpineAnim("attack");
        for (int i = 0; i < targetList.Count; i++)
        {
            var enemy = targetList[i];
            var targetView = GameMgr.Entity.GetEntityView<BattleUnitView>(enemy.Id);
            var offset = Vector3.right * (-(targetList.Count - 1) / 2f + i) * 2f;
            targetView.PlaySpineAnim("defend", null, offset);
        }
    }

    public List<Role> GetSkillTargetList(int skillId, Role caster, Role target)
    {
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        if (cfg.IsMulti)
        {
            return Data.GetRoleList(cfg.TargetPos, !caster.Battle.IsLeft);
        }

        var targetList = new List<Role>();
        targetList.Add(target);

        return targetList;
    }

    public bool CheckHit(int hit)
    {
        hit = Mathf.Clamp(hit, 0, 100);
        var random = UnityEngine.Random.Range(0, 100);
        return random < hit;
    }
}
