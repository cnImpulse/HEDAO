using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FGUI.Common;
using UnityEngine;

public abstract class ActionStateBase : FsmState
{
    public new MenuAction Owner => base.Owner as MenuAction;
    public FGUIMenuAction View => Owner.View as FGUIMenuAction;
    protected GList m_list => View.m_panel_action.m_list_action;
    
    public override void OnEnter()
    {
        base.OnEnter();

    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
}
