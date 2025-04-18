using System.Collections;
using System.Collections.Generic;
using FairyGUI;
using FGUI.Common;
using UnityEngine;

public abstract class ActionStateBase : FsmState
{
    public new MenuAction Owner => base.Owner as MenuAction;
    public FGUIMenuAction View => Owner.View as FGUIMenuAction;
    public GridMap GridMap => GameMgr.Battle.Data.GridMap;
    public GridMapView GridMapView => GameMgr.Battle.GridMapView;
    public GridUnit BattleUnit => Owner.BattleUnit;
    public GridUnitView BattleUnitView => GameMgr.Entity.GetEntityView<GridUnitView>(BattleUnit.Id);
    protected GList m_list => View.m_panel_action.m_list_action;
    protected GLabel m_txt_info => View.m_panel_action.m_txt_info;

    public override void OnEnter()
    {
        base.OnEnter();

    }

    public override void OnLeave()
    {

        base.OnLeave();
    }
}
