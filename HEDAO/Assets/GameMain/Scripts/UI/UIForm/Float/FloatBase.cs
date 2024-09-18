using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cfg;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class FloatBase : FGUIForm<FGUIFloatGridUnit>
    {
        private EntityView m_Owner = default;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Owner = userData as EntityView;
            View.m_title.text = m_Owner.Data.Name.ToString();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            Vector3 screenPos = Camera.main.WorldToScreenPoint(m_Owner.transform.position);
            screenPos.y = Screen.height - screenPos.y;
            View.SetXY(screenPos.x, screenPos.y + 15);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }
    }
}