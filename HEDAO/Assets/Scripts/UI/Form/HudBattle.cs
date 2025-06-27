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

        View.m_comp_skill_result.m_btn_sure.onClick.Set(OnClickReleaseSkill);

        View.m_list_action.itemRenderer = OnRenderRole;
        View.m_comp_skill.m_list_skill.itemRenderer = OnRenderSkill;
        View.m_comp_skill.m_list_skill.RefreshSelectionCtrl();
        View.m_comp_skill.m_list_skill.selectionController.onChanged.Set(RefreshSkill);
    }

    protected override void OnShow()
    {
        base.OnShow();

        RefreshRolePanel();
        RefreshSkill();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        var state = GameMgr.Battle.Fsm.CurState;
        View.m_txt_battle_state.text = state.ToString();
        RefreshActionList();
    }

    protected override void OnClose()
    {
        GameMgr.Event.Unsubscribe(GameEventType.OnClickBattleUnit, OnClickBattleUnit);

        base.OnClose();
    }

    public void RefreshActionList()
    {
        //View.m_list_action.RefreshList(GameMgr.Battle.Data.BattleUnitQueue.ToList());
    }

    private void OnRenderSkill(int index, GObject item, object data)
    {
        var skillId = (int)data;
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        item.asButton.title = cfg.Name;
        //item.enabled = cfg.LaunchPos.Contains(CurBattleUnit.Battle.PosIndex);
    }

    private void OnRenderRole(int index, GObject item, object data)
    {
        //var role = (data as GridUnit).Role;
        //var btn = item as FGUIBtnRole;
        //btn.mode = ButtonMode.Common;
        //btn.Refresh(role);
    }

    private long m_SelectEffectId = 0;
    private void OnClickBattleUnit(GameEvent e)
    {
        m_SelectedTarget = null;
        var data = View.m_comp_skill.m_list_skill.selectedData;
        if (data == null) return;

        var target = e.Data as BattleUnitView;
        if (!(target.Entity is EnemyRole)) return;

        var skillId = (int)data;
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        if (cfg.TargetPos.Contains(-target.Entity.Battle.PosIndex))
        {
            SelectedTarget = target;
        }
    }

    private void RefreshRolePanel()
    {
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
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
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

        var visible = HasSelectedSkill && SelectedTarget != null;
        View.m_comp_skill_result.visible = visible;
        if (!visible)
        {
            return;
        }

        m_SelectEffectId = GameMgr.Effect.ShowEffect(10006, SelectedTarget.Id);
        View.m_comp_skill_result.m_txt_result.text = SkillUtil.GetSkillDesc(SelectedSkillId, CurBattleUnit, SelectedTarget.Entity);
    }

    //private List<long> TargetEffectList = new List<long>();
    private void ShowSkillTarget(int skillId)
    {
        GameMgr.Effect.HideEffectByPrefabId(10007);

        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        foreach(var pos in cfg.TargetPos)
        {
            var enemy = GameMgr.Battle.Data.GetRole(-pos);
            if (enemy != null)
            {
                var effectId = GameMgr.Effect.ShowEffect(new EffectData() { PrefabId = 10007, FollowId = enemy.Id });
                //TargetEffectList.Add(effectId);
            }
        }
    }

    private void OnClickReleaseSkill()
    {
    }
}
