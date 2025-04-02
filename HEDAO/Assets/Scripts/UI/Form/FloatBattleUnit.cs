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
    }

    protected override void OnShow()
    {
        base.OnShow();

    }
    
    public override void OnUpdate()
    {
        base.OnUpdate();

        View.m_hp_bar.value = Owner.Entity.HP;
        View.m_hp_bar.max = Owner.Entity.MaxHP;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(Owner.transform.position);
        screenPos.y = Screen.height - screenPos.y;
        View.SetXY(screenPos.x, screenPos.y);
    }
}
