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

        GameMgr.Event.Subscribe(GameEventType.OnPlayerRoundStart, OnPlayerRoundStart);

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

        GameMgr.Effect.ShowEffect(new EffectData() { PrefabId = 10006, FollowId = CurBattleUnit.Id });
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
        GameMgr.Event.Unsubscribe(GameEventType.OnPlayerRoundStart, OnPlayerRoundStart);

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
    
    private void OnPlayerRoundStart(GameEvent obj)
    {
    }

    private void RefreshRolePanel()
    {
        var btn = View.m_comp_skill.m_btn_role as FGUIBtnRole;
        btn.mode = ButtonMode.Common;
        btn.Refresh(CurBattleUnit);

        View.m_comp_skill.m_list_skill.RefreshList(CurBattleUnit.Skill.SkillSet.ToList());
    }

    private void RefreshSkill()
    {
        var data = View.m_comp_skill.m_list_skill.selectedData;
        var hasSkill = data != null;
        View.m_comp_skill.m_txt_skill.visible = hasSkill;
        View.m_comp_skill.m_comp_skill_pos.visible = hasSkill;
        if (!hasSkill)
        {
            return;
        }

        var skillId = (int)data;
        var cfg = GameMgr.Cfg.TbSkill.Get(skillId);
        View.m_comp_skill.m_txt_skill.text = SkillUtil.GetSkillDesc(skillId);
        View.m_comp_skill.m_comp_skill_pos.Refresh(skillId);
    }
}
