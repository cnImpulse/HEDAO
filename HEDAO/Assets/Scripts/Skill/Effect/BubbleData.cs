using System;
using Cfg.Battle;
using UnityEngine;

public class BubbleData
{
    public long TargetId;
    public string Text;
    public Color32 Color;

    public BubbleData()
    {
        ColorUtility.TryParseHtmlString("#FF7777", out Color color);
        Color = color;
    }
}

