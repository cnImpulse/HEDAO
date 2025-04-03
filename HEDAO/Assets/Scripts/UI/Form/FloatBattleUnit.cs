using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class FloatBattleUnit : UIBase
{
    public GridUnitView Owner;
    public new FGUIFloatBattleUnit View => base.View as FGUIFloatBattleUnit;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        Owner = userData as GridUnitView;
        View.m_txt_name.text = Owner.Entity.Role.Name;
    }

    protected override void OnShow()
    {
        base.OnShow();

    }
    
    public override void OnUpdate()
    {
        base.OnUpdate();

        var attr = Owner.Entity.Role.Attr;
        View.m_hp_bar.value = attr.HP;
        View.m_hp_bar.max = attr.MaxHP;
        View.m_qi_bar.value = attr.QI;
        View.m_qi_bar.max = attr.MaxQI;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(Owner.transform.position);
        screenPos.y = Screen.height - screenPos.y;
        View.SetXY(screenPos.x, screenPos.y);
    }
}
