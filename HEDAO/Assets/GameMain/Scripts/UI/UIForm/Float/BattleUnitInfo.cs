using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class BattleUnitInfo : FGUIForm<FGUIBattleUnitInfo>
    {
        private BattleUnit m_Owner = default;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Owner = userData as BattleUnit;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            View.m_hp_bar.value = m_Owner.Data.HP;
            View.m_qi_bar.value = m_Owner.Data.QI;
            View.m_hp_bar.max = m_Owner.Data.MaxHP;
            View.m_qi_bar.max = m_Owner.Data.MaxQI;

            Vector3 screenPos = Camera.main.WorldToScreenPoint(m_Owner.transform.position);
            screenPos.y = Screen.height - screenPos.y;
            View.SetXY(screenPos.x, screenPos.y + 55f);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }
    }
}