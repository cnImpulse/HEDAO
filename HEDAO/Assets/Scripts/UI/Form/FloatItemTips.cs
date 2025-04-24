using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;
using Cfg;
using System.Collections.Generic;

public enum EItemOptionType
{
    [EnumName("装备")]
    Wear,
    [EnumName("卸载")]
    UnWear,
    [EnumName("丢弃")]
    Throw,
}

public class FloatItemTipsParams
{
    public ItemData Item;
    public Role Target;
    public Vector2 Postion;
    public Action CallBack;
}

public class FloatItemTips : UIBase
{
    public new FGUIFloatItemTips View => base.View as FGUIFloatItemTips;
    public FloatItemTipsParams Param;

    private static List<EItemOptionType> s_OptionList = new List<EItemOptionType> { EItemOptionType.Wear, EItemOptionType.Throw };

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        Param = userData as FloatItemTipsParams;

        View.m_list_select.itemRenderer = OnRenderSelect;
        AdjustPostion();
    }

    private void AdjustPostion()
    {
        Vector2 viewSize = new Vector2(View.width, View.height);
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector2 minPos = Vector2.one;
        Vector2 maxPos = screenSize - viewSize;

        Vector2 clamPos = new Vector2(Mathf.Clamp(Param.Postion.x, minPos.x, maxPos.x), Mathf.Clamp(Param.Postion.y, minPos.y, maxPos.y));
        View.position = clamPos;
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
        if (type == EItemOptionType.Wear)
        {
            if (Param.Target == null) return;

            Param.Target.Equip.Slot.AddItem(Param.Item as Equip);
        }
        else if (type == EItemOptionType.UnWear)
        {
            GameMgr.Save.Data.HomeData.Store.AddItem(Param.Item);
        }
        else if (type == EItemOptionType.Throw)
        {
            Param.Item.Throw();
        }

        Close();
        Param.CallBack?.Invoke();
    }
}
