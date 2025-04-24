using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;
using Cfg;
using System.Collections.Generic;

public enum EItemOptionType
{
    [EnumName("装备")]
    Equip,
    [EnumName("丢弃")]
    Throw,
}

public class FloatItemTipsParams
{
    public ItemData Item;
    public Role Target;
    public Vector2 Postion;
}

public class FloatItemTips : UIBase
{
    public new FGUIFloatItemTips View => base.View as FGUIFloatItemTips;
    public FloatItemTipsParams Param;

    private static List<EItemOptionType> s_OptionList = new List<EItemOptionType> { EItemOptionType.Equip, EItemOptionType.Throw };

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        Param = userData as FloatItemTipsParams;

        View.m_list_select.itemRenderer = OnRenderSelect;
        View.position = Param.Postion;
    }

    protected override void OnShow()
    {
        base.OnShow();

        View.m_title.text = Param.Item.GetDesc();
        View.m_list_select.RefreshList(Param.Item.GetOptionList());
    }

    private void OnRenderSelect(int index, GObject obj, object data)
    {
        var type = (EItemOptionType)data;
        var ctrl = obj.asButton;

        ctrl.title = type.GetName();
        ctrl.onClick.Set(() => OnClickOption(type));
    }

    public void OnClickOption(EItemOptionType type)
    {
        if (type == EItemOptionType.Equip)
        {
            if (Param.Target == null) return;

            Param.Target.Equip.AddEquip(Param.Item as Equip);
        }
    }
}
