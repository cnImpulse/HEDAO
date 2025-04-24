using System;
using System.Collections.Generic;
using Cfg;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class MenuRole : UIBase
{
    public new FGUIMenuRole View => base.View as FGUIMenuRole;

    public List<Role> RoleList;
    public Role Role => View.m_comp_role.m_list_role.selectedData as Role;

    private static List<EEquipType> m_EquipTypeList = new List<EEquipType> { EEquipType.Weapon, EEquipType.Armour, EEquipType.Trinket };
    private static List<EBookType> m_BookTypeList = new List<EBookType> { EBookType.DaoFa, EBookType.ShuFa, EBookType.DunFa };

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        RoleList = userData as List<Role>;
        //View.m_list_role.m_list.itemRenderer = OnRenderRole;
        //View.m_list_role.m_list.RefreshList();

        View.m_comp_role.m_list_role.itemRenderer = OnRenderRole;
        View.m_comp_role.m_list_equip.itemRenderer = OnRenderEquipSlot;
        View.m_comp_role.m_list_book.itemRenderer = OnRenderBookSlot;
        View.m_comp_store.m_list_item.itemRenderer = OnRenderItem;

        View.m_comp_role.m_list_role.selectionController.onChanged.Set(RefreshRole);
        View.m_comp_role.m_list_role.RefreshList(RoleList);
    }

    protected override void OnShow()
    {
        base.OnShow();

    }

    private void RefreshRole()
    {
        if (Role == null) return;

        View.m_rader.Refresh(Role);
        View.m_txt_attr.text = RoleUtil.GetRoleAttrInfo(Role);
        View.m_txt_skill.text = RoleUtil.GetRoleSkillInfo(Role);

        View.m_comp_role.m_txt_name.text = Role.Name;
        View.m_comp_role.m_list_equip.RefreshList(m_EquipTypeList);
        View.m_comp_role.m_list_book.RefreshList(m_BookTypeList);

        View.m_comp_store.m_list_item.RefreshList(GameMgr.Save.Data.HomeData.Store.GetDataList());
    }

    private void OnRenderRole(int index, GObject obj, object data)
    {
        var role = data as Role;
        var item = obj.asButton;
        item.text = role.Name;
    }

    private void OnRenderEquipSlot(int index, GObject obj, object data)
    {
        var type = (EEquipType)data;
        var ctrl = obj as FGUICompSlot;

        var item = Role.Equip.GetEquip(type);
        ctrl.m_btn_slot.title = item != null ? item.Cfg.Name : "";
        ctrl.m_txt_type.text = type.GetName();
    }

    private void OnRenderBookSlot(int index, GObject obj, object data)
    {
        var type = (EBookType)data;
        var ctrl = obj as FGUICompSlot;

        var cfgId = Role.Book.GetBook(type);
        ctrl.m_btn_slot.title = cfgId != 0 ? GameMgr.Cfg.TbBook.Get(cfgId).Name : "";
        ctrl.m_txt_type.text = type.GetName();
    }

    private void OnRenderItem(int index, GObject obj, object data)
    {
        var item = data as ItemData;
        var ctrl = obj.asButton;

        ctrl.title = item == null ? "" : item.Cfg.Name;
        ctrl.onClick.Set((e) => OnClickItem(e, item));
    }

    private void OnClickItem(EventContext e, ItemData item)
    {
        if (item == null) return;

        //GameMgr.UI.ShowTips(item.GetDesc(), e.inputEvent.position);
        var param = new FloatItemTipsParams();
        param.Item = item;
        param.Target = Role;
        param.Postion = e.inputEvent.position;

        GameMgr.UI.ShowUI(UIName.FloatItemTips, param);
    }
}
