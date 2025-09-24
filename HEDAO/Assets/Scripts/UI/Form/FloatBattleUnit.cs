using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class FloatBattleUnit : UIBase
{
    public BattleUnitView Owner;
    public new FGUIFloatBattleUnit View => base.View as FGUIFloatBattleUnit;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        Owner = userData as BattleUnitView;
        View.m_txt_name.text = Owner.Entity.Name;
    }

    protected override void OnShow()
    {
        base.OnShow();

    }
    
    public override void OnUpdate()
    {
        base.OnUpdate();

        var attr = Owner.Entity.Attr;
        View.m_hp_bar.value = Mathf.Max(0, attr.HP);
        View.m_hp_bar.max = attr.MaxHP;
        View.m_qi_bar.value = Mathf.Max(0, attr.QI);
        View.m_qi_bar.max = attr.MaxQI;
        View.m_txt_name.color = Owner.Entity is PlayerRole? Color.white : Color.red;
        RefreshShieldBar();
        RefreshBuffList();
        
        Vector3 screenPos = UIUtil.World2ScreenPos(Owner.transform.position);
        View.SetXY(screenPos.x, screenPos.y);
    }

    private void RefreshShieldBar()
    {
        var buff = Owner.Entity.Buff.GetBuff<ShieldBuff>();
        var visible = buff != null;
        View.m_shield_bar.visible = visible;
        if (!visible) return;

        View.m_shield_bar.value = buff.Durability;
        View.m_shield_bar.max = buff.MaxDurability;
    }

    private void RefreshBuffList()
    {
        View.m_list_buff.visible = false;
    }
}