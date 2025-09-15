using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleAI : BattleStateBase
{
    public override void OnEnter()
    {
        base.OnEnter();

        GameMgr.Event.Subscribe(GameEventType.OnBattleUnitActionEnd, OnPlayerRoundEnd);
        
        GameMgr.Effect.ShowFxSelect(CurBattleUnit.Id);
        AutoAction();
    }

    public override void OnLeave()
    {
        GameMgr.Effect.HideEffectByPrefabId(10006);
        Data.BattleUnitQueue.Dequeue();
        
        GameMgr.Event.Unsubscribe(GameEventType.OnBattleUnitActionEnd, OnPlayerRoundEnd);
        
        base.OnLeave();
    }

    private void AutoAction()
    {
        var skillList = CurBattleUnit.Skill.GetValidSkillList(Data);
        if (skillList.Count == 0)
        {
            GameMgr.Event.Fire(GameEventType.OnBattleUnitActionEnd);
            return;
        }

        var skillId = skillList.GetRandom();
        var target = SelectTarget(skillId);
        
        GameMgr.Battle.PlaySkill(skillId, CurBattleUnit, target);
    }

    private Role SelectTarget(int skillId)
    {
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        var targetList =  Data.GetRoleList(cfg.TargetPos, !CurBattleUnit.Battle.IsLeft);
        return targetList.GetRandom();
    }
    
    private void OnPlayerRoundEnd(GameEvent obj)
    {
        if (Data.BattleResult == EResult.None)
        {
            ChangeState<BattleLoop>();
        }
        else
        {
            ChangeState<BattleEnd>();
        }
    }
}
