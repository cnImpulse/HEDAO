using System;
using UnityEngine;
using FairyGUI;
using FGUI.Common;

public class FloatTipsParams
{
    public string Text;
    public Vector2 Position;
}

public class FloatTips : UIBase
{
    public new FGUIFloatTips View => base.View as FGUIFloatTips;

    protected override void OnInit(object userData)
    {
        base.OnInit(userData);

        var data = userData as FloatTipsParams;
        View.m_label.text = data.Text;
        View.m_label.position = data.Position;
    }

    protected override void OnShow()
    {
        base.OnShow();

    }
}
