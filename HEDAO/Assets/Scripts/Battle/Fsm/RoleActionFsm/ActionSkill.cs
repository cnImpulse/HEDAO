using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using UnityEngine;

public class ActionSkill : ActionStateBase
{
    public List<int> SkillList => Owner.BattleUnit.Role.SkillSet.ToList();
    
    public override void OnEnter( )
    {
        base.OnEnter();

        View.m_panel_action.m_title.text = "术";
        m_list.itemRenderer = OnRenderAction;
        m_list.numItems = SkillList.Count;
        m_list.ResizeToFit();
    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
    
    private void OnRenderAction(int index, GObject item, object data)
    {
        var cfgId = SkillList[index];
        var cfg = GameMgr.Cfg.TbSkill.Get(cfgId);
        item.text = cfg.Name;
        item.onClick.Set(()=>OnClickAction(cfgId));
    }
    
    private void OnClickAction(int cfgId)
    {
    }
}
