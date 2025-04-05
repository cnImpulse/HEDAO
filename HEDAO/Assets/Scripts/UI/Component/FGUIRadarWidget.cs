using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using Cfg;
using UnityEngine;

namespace FGUI.Common
{
    public partial class FGUIRadarWidget : GComponent
    {
        public void Refresh(Role role)
        {
            if (role == null) return;

            float[] arr = new float[5];
            foreach (var pair in role.WuXin)
            {
                var index = (int)pair.Key - 1;
                var value = pair.Value / 100f;
                arr[index] = value;
                var text = GetChildAt(GetChildIndex(m_text_wuxin_0) + index);
                text.text = $"{pair.Key.GetName()}：{pair.Value}";
            }

            m_img_wuxing.shape.DrawRegularPolygon(5, 4, Color.white,
                Color.black, Color.white, 54, arr);
        }
    }
}