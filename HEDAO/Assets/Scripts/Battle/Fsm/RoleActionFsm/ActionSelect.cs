using System.Collections;
using System.Collections.Generic;
using Cfg;
using FairyGUI;

public class ActionSelect : ActionStateBase
{
    public List<RoleActionType> ActionList = new()
        { RoleActionType.Skill, RoleActionType.Move, RoleActionType.Wait };
    
    public override void OnEnter()
    {
        base.OnEnter();

        View.m_panel_action.m_title.text = "令";
        m_list.itemRenderer = OnRenderAction;
        m_list.numItems = ActionList.Count;
        m_list.ResizeToFit();
    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
    
    private void OnRenderAction(int index, GObject item, object data)
    {
        var type = ActionList[index];
        item.text = type.GetName();
        item.onClick.Set(()=>OnClickAction(type));
    }
    
    private void OnClickAction(RoleActionType type)
    {
        if (type == RoleActionType.Move)
        {
            ChangeState<ActionMove>();
        }
    }
}
