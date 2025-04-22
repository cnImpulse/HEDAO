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

    private static List<EEquipType> m_EquipTypeList = new List<EEquipType> { EEquipType.Weapon, EEquipType.Armour, EEquipType.Trinket };

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        Role = userData as Role;
        //View.m_list_role.m_list.itemRenderer = OnRenderRole;
        //View.m_list_role.m_list.RefreshList();

        View.m_comp_role.m_list_equip.itemRenderer = OnRenderEquipSlot;
    }

    protected override void OnShow()
    {
        base.OnShow();

        View.m_comp_role.m_list_equip.RefreshList(m_EquipTypeList);
        RefreshRole();
    }
    
    private void RefreshRole()
    {
        View.m_txt_attr.text = RoleUtil.GetRoleAttrInfo(Role);
        View.m_txt_skill.text = RoleUtil.GetRoleSkillInfo(Role);
        View.m_rader.Refresh(Role);
    }

    private void OnRenderEquipSlot(int index, GObject obj, object data)
    {
        var type = (EEquipType)data;
        var ctrl = obj as FGUICompSlot;

        var item = Role.Equip.GetEquip(type);
        ctrl.m_btn_slot.title = item != null ? item.Cfg.Name : "";
        ctrl.m_txt_type.text = type.GetName();
    }
}
