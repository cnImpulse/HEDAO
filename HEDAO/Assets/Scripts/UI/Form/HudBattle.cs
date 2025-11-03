using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using FGUI.Common;
using System.Linq;

public class HudBattle : UIBase
{
    public new FGUIHudBattle View => base.View as FGUIHudBattle;
    public Role CurBattleUnit => GameMgr.Battle.Data.BattleUnitQueue.Peek();

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        GameMgr.Event.Subscribe(GameEventType.OnClickBattleUnit, OnClickBattleUnit);
        GameMgr.Event.Subscribe(GameEventType.OnBattleUnitDead, OnBattleUnitDead);
        GameMgr.Event.Subscribe(GameEventType.OnPlayerRoundStart, OnPlayerRoundStart);
        GameMgr.Event.Subscribe(GameEventType.OnBattleEnd, OnBattleEnd);

        View.m_comp_skill_result.m_btn_sure.onClick.Set(OnClickReleaseSkill);
        View.m_comp_skill.m_btn_jump.onClick.Set(OnClickJump);
        
        View.m_list_action.itemRenderer = OnRenderActionRole;

        View.m_comp_skill.m_list_skill.itemRenderer = OnRenderSkill;
        View.m_comp_skill.m_list_skill.RefreshSelectionCtrl();
        View.m_comp_skill.m_list_skill.selectionController.onChanged.Set(RefreshSkill);
    }
    
    private void OnBattleEnd(GameEvent obj)
    {
        GameMgr.UI.ShowUI(UIName.MenuBattleEnd, obj.Data);
    }

    private void OnPlayerRoundStart(GameEvent obj)
    {
        RefreshRolePanel();
    }

    private void OnBattleUnitDead(GameEvent obj)
    {
        Refresh();
    }

    protected override void OnShow()
    {
        base.OnShow();

        RefreshActionList();
        RefreshRolePanel();
        RefreshSkill();
    }

    private FsmState lastState;
    public override void OnUpdate()
    {
        base.OnUpdate();

        var state = GameMgr.Battle.Fsm.CurState;
        View.m_txt_battle_state.text = state.ToString();

        RefreshActionList();
        if (lastState != state)
        {
            RefreshRolePanel();
        }
        lastState = state;
    }

    protected override void OnClose()
    {
        GameMgr.Event.Unsubscribe(GameEventType.OnClickBattleUnit, OnClickBattleUnit);
        GameMgr.Event.Unsubscribe(GameEventType.OnBattleUnitDead, OnBattleUnitDead);
        GameMgr.Event.Unsubscribe(GameEventType.OnPlayerRoundStart, OnPlayerRoundStart);
        GameMgr.Event.Unsubscribe(GameEventType.OnBattleEnd, OnBattleEnd);

        base.OnClose();
    }

    public void RefreshActionList()
    {
        View.m_list_action.RefreshList(GameMgr.Battle.Data.BattleUnitQueue.ToList());
    }

    private void OnRenderSkill(int index, GObject item, object data)
    {
        var skillId = (int)data;
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        item.asButton.title = cfg.Name;
        if (!CurBattleUnit.Skill.IsValidSkill(skillId))
        {
            item.asButton.title += "\n(不可用)";
        }
    }

    private void OnRenderActionRole(int index, GObject item, object data)
    {
        var role = data as Role;
        var btn = item as FGUIBtnRole;
        btn.Refresh(role, false);
        btn.onRollOver.Set(() =>
        {
            m_SelectEffectId =  GameMgr.Effect.ShowFxSelect(role.Id);
        });
        btn.onRollOut.Set(() =>
        {
            GameMgr.Effect.HideEffect(m_SelectEffectId);
        });
    }

    private long m_SelectEffectId = 0;
    private void OnClickBattleUnit(GameEvent e)
    {
        SelectedTarget = null;
        var data = View.m_comp_skill.m_list_skill.selectedData;
        if (data == null) return;

        var skillId = (int)data;
        var target = e.Data as BattleUnitView;
        var targetList = GameMgr.Battle.GetSkillVaildTargetList(skillId, CurBattleUnit);
        if (!targetList.Contains(target.Entity)) return;
        
        SelectedTarget = target;
    }

    private void RefreshRolePanel()
    {
        var visible = GameMgr.Battle.Fsm.CurState is BattlePlayer;
        View.m_comp_skill.visible = visible;
        if (!visible)
        {
            ExitPlaySkill();
            return;
        }

        var btn = View.m_comp_skill.m_btn_role as FGUIBtnRole;
        btn.mode = ButtonMode.Common;
        btn.Refresh(CurBattleUnit);

        View.m_comp_skill.m_list_skill.RefreshList(CurBattleUnit.Skill.SkillSet.ToList());
    }

    private bool HasSelectedSkill => View.m_comp_skill.m_list_skill.selectedData != null;
    private int SelectedSkillId => (int)View.m_comp_skill.m_list_skill.selectedData;

    private void RefreshSkill()
    {
        SelectedTarget = null;

        var hasSkill = HasSelectedSkill;
        View.m_comp_skill.m_txt_skill.visible = hasSkill;
        View.m_comp_skill.m_comp_skill_pos.visible = hasSkill;
        if (!hasSkill)
        {
            GameMgr.Effect.HideEffectByPrefabId(10007);
            return;
        }

        var skillId = SelectedSkillId;
        View.m_comp_skill.m_txt_skill.text = SkillUtil.GetSkillDesc(skillId);
        View.m_comp_skill.m_comp_skill_pos.Refresh(skillId);

        ShowSkillTarget(skillId);
        RefreshSkillResult();
    }

    private BattleUnitView m_SelectedTarget;
    private BattleUnitView SelectedTarget
    {
        get => m_SelectedTarget;
        set
        {
            m_SelectedTarget = value;
            RefreshSkillResult();
        }
    }

    private void RefreshSkillResult()
    {
        GameMgr.Effect.HideEffect(m_SelectEffectId);
        
        var visible = HasSelectedSkill && SelectedTarget != null && CurBattleUnit.Skill.IsValidSkill(SelectedSkillId);
        View.m_comp_skill_result.visible = visible;
        if (!visible)
        {
            return;
        }

        View.m_comp_skill_result.m_txt_result.text = SkillUtil.GetSkillDesc(SelectedSkillId, CurBattleUnit, SelectedTarget.Entity);
        if (SelectedTarget.Entity != CurBattleUnit)
        {
            m_SelectEffectId = GameMgr.Effect.ShowFxSelect(SelectedTarget.Id);
        }
    }

    private void ShowSkillTarget(int skillId)
    {
        GameMgr.Effect.HideEffectByPrefabId(10007);
        if (!CurBattleUnit.Skill.IsValidSkill(skillId))
        {
            return;
        }
        
        var targetList = GameMgr.Battle.GetSkillVaildTargetList(skillId, CurBattleUnit);
        foreach(var target in targetList)
        {
            GameMgr.Effect.ShowEffect(new EffectData() { PrefabId = 10007, FollowId = target.Id });
        }
    }

    private void OnClickReleaseSkill()
    {
        if (!CurBattleUnit.Skill.IsValidSkill(SelectedSkillId))
        {
            return;
        }
        
        GameMgr.Battle.PlaySkill(SelectedSkillId, CurBattleUnit, SelectedTarget.Entity);

        GameMgr.Effect.HideEffectByPrefabId(10006);
        
        ExitPlaySkill();
    }
    
    private void OnClickJump()
    {
        GameMgr.Event.Fire(GameEventType.OnBattleUnitActionEnd);
    }

    private void ExitPlaySkill()
    {
        SelectedTarget = null;
        GameMgr.Effect.HideEffectByPrefabId(10007);
    }
}
