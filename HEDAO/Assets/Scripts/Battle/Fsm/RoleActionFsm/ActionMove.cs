using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using UnityEngine;

public class ActionMove : ActionStateBase
{
    public List<int> MoveSkillList => Owner.BattleUnit.Role.MoveSkillSet.ToList();

    public override void OnEnter()
    {
        base.OnEnter();
        
        View.m_panel_action.m_title.text = "行";
        m_list.itemRenderer = OnRenderAction;
        m_list.numItems = MoveSkillList.Count;
        m_list.ResizeToFit();
    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
    
    private void OnRenderAction(int index, GObject item, object data)
    {
        var cfgId = MoveSkillList[index];
        var cfg = GameMgr.Cfg.TbMoveSkill.Get(cfgId);
        item.text = cfg.Name;
        item.onClick.Set(()=>OnClickMoveSkill(cfgId));
    }
    
    private void OnClickMoveSkill(int cfgId)
    {
    }
}
