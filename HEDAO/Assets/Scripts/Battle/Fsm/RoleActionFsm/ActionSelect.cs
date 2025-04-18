using System.Collections;
using System.Collections.Generic;
using Cfg;
using FairyGUI;

public class ActionSelect : ActionStateBase
{
    public List<BattleUnitActionType> ActionList = new()
        { BattleUnitActionType.Skill, BattleUnitActionType.Wait };
    
    public override void OnEnter()
    {
        base.OnEnter();

        View.m_panel_action.m_title.text = "令";
        m_list.itemRenderer = OnRenderAction;
        m_list.numItems = ActionList.Count;
        m_list.ResizeToFit();

        // GameMgr.Effect.ShowEffect(10003, GridMapUtl.GridPos2WorldPos(BattleUnit.GridPos), true);
    }

    public override void OnLeave()
    {
        GameMgr.Effect.HideEffectByPrefabId(10003);
        
        base.OnLeave();
    }
    
    private void OnRenderAction(int index, GObject item, object data)
    {
        var type = ActionList[index];
        item.text = type.GetName();
        item.asButton.mode = ButtonMode.Common;
        item.onClick.Set(()=>OnClickAction(type));
    }
    
    private void OnClickAction(BattleUnitActionType type)
    {
        if (type == BattleUnitActionType.Skill)
        {
            ChangeState<ActionSkill>();
        }
        else if (type == BattleUnitActionType.Wait)
        {
            ChangeState<ActionWait>();
        }
    }
}
