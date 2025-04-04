using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using UnityEngine;

public class ActionSkill : ActionStateBase
{
    public int CurCfgId = 0;
    public List<int> SkillList => Owner.BattleUnit.Role.SkillSet.ToList();
    
    public override void OnEnter( )
    {
        base.OnEnter();

        View.m_btn_check.onClick.Set(OnClickCheck);

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
        CurCfgId = cfgId;
    }

    private void OnClickCheck()
    {
        if (CurCfgId > 0)
        {
            CurCfgId = 0;
            GameMgr.Effect.HideGridEffect();
        }
        else
        {
            Fsm.ChangeState<ActionSelect>();
        }
    }
}
