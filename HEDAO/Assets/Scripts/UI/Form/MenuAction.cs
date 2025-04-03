using System;
using System.Collections.Generic;
using System.Linq;
using Cfg;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public enum RoleActionType
{
    None = 0,
    [EnumName("术法")]
    Skill,
    [EnumName("遁术")]
    Move,
    [EnumName("调息")]
    Wait,
}

public class MenuAction : UIBase
{
    public new FGUIMenuAction View => base.View as FGUIMenuAction;
    public GridUnit Owner => GameMgr.Battle.Data.BattleUnitQueue.Peek();

    private RoleActionType m_CurAction;
    public RoleActionType CurActionType
    {
        get => m_CurAction;
        set
        {
            if (m_CurAction != value)
            {
                m_CurAction = value;
                RefreshActionList();
            }
        }
    }

    public List<int> MoveSkillList => Owner.Role.MoveSkillSet.ToList();
    public List<RoleActionType> ActionList = new()
        { RoleActionType.Skill, RoleActionType.Move, RoleActionType.Wait };
    
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        View.m_btn_check.onClick.Set(OnClickCheck);
        View.m_panel_action.m_list_action.itemRenderer = OnRenderAction;
        View.m_panel_action.text = "行动";
    }

    protected override void OnShow()
    {
        base.OnShow();

        RefreshActionList();
    }

    private void InitFsm()
    {
        // Fsm = Fsm.CreatFsm(new BattlePrepare(), new BattleStart(), new BattleLoop(), new BattleEnd(),
        //     new BattlePlayer(), new BattleAI());
    }

    public void RefreshActionList()
    {
        if (CurActionType == RoleActionType.Move)
        {
            View.m_panel_action.m_list_action.numItems = MoveSkillList.Count;
        }
        else
        {
            View.m_panel_action.m_list_action.numItems = ActionList.Count;
        }
        View.m_panel_action.m_list_action.ResizeToFit();
    }
    
    private void OnRenderAction(int index, GObject item, object data)
    {
        if (CurActionType == RoleActionType.Move)
        {
            var cfgId = MoveSkillList[index];
            var cfg = GameMgr.Cfg.TbMoveSkill.Get(cfgId);
            item.text = cfg.Name;
            item.onClick.Set(()=>OnClickMoveSkill(cfgId));
        }
        else
        {
            var type = ActionList[index];
            item.text = type.GetName();
            item.onClick.Set(()=>OnClickAction(type));
        }
    }

    private void OnClickMoveSkill(int cfgId)
    {
    }

    private void OnClickAction(RoleActionType type)
    {
        CurActionType = type;
    }
    
    private void OnClickCheck()
    {
        CurActionType = RoleActionType.None;
    }
}
