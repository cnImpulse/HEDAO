using System.Collections;
using System.Collections.Generic;
using Cfg;
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

            var hp = m_Owner.Data.HP;
            var maxHp = m_Owner.Data.MaxHP;
            int shield = m_Owner.Data.RoleData.BattleAttr.GetAttr(EAttrType.Shield);
            var text = shield > 0 ? $"{hp}+{shield}/{maxHp}+{shield}" : $"{hp}/{maxHp}";
            
            View.m_hp_bar.value = hp + shield;
            View.m_hp_bar.max = maxHp + shield;
            View.m_hp_bar.m_text.text = text;
            
            View.m_qi_bar.value = m_Owner.Data.QI;
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