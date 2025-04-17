using System;
using DG.Tweening;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class FloatBubble : UIBase
{
    public new FGUIFloatBubble View => base.View as FGUIFloatBubble;
    public Vector3 TargetPos;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        var data = userData as OnTakeEffectEvent;
        var gridUnit = data.Target as GridUnit;
        TargetPos = GridMapUtl.GridPos2WorldPos(gridUnit.GridPos);
        View.m_title.text = data.IsMiss ? "miss" : data.Damage.ToString();

        DOVirtual.DelayedCall(2f, Close);
    }

    protected override void OnShow()
    {
        base.OnShow();

    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        
        View.position = UIUtil.World2ScreenPos(TargetPos);
    }
}
