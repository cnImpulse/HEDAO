using System;
using System.Collections.Generic;
using Cfg;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class MenuRole : UIBase
{
    public Role Role;
    public new FGUIMenuRole View => base.View as FGUIMenuRole;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        Role = userData as Role;
        // View.m_list_role.m_list.itemRenderer = OnRenderRole;
        // View.m_list_role.m_list.RefreshList();
    }

    protected override void OnShow()
    {
        base.OnShow();

        RefreshRole();
    }
    
    private void RefreshRole()
    {
        View.m_txt_role.text = RoleUtil.GetRoleInfo(Role);
        View.m_rader.Refresh(Role);
    }
}
