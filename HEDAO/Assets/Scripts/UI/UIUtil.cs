using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIUtil
{
    public static Vector3 World2ScreenPos(Vector3 position)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(position);
        screenPos.y = Screen.height - screenPos.y;
        return screenPos;
    }
}
