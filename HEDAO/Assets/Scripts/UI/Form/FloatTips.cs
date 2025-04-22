using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class FloatTips : UIBase
{
    public new FGUIFloatTips View => base.View as FGUIFloatTips;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        var e = userData as EventContext;
        View.m_label.text = e.data.ToString();
        View.m_label.position = e.inputEvent.position;
    }

    protected override void OnShow()
    {
        base.OnShow();

    }
}
