using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using FairyGUI.Utils;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class HPBar : GSlider
    {
        private BattleUnit m_Owner = default;

        public static HPBar CreateInstance(BattleUnit battleUnit)
        {
            var instance = (HPBar)UIPackage.CreateObject("CommonUI", "HPBar", typeof(HPBar));
            GRoot.inst.AddChild(instance);
            instance.Init(battleUnit);
            return instance;
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

        }

        protected void Init(BattleUnit battleUnit)
        {
            m_Owner = battleUnit;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            value = m_Owner.Data.HP;
            max = m_Owner.Data.MaxHP;

            Vector3 screenPos = Camera.main.WorldToScreenPoint(m_Owner.transform.position);
            screenPos.y = Screen.height - screenPos.y;
            SetXY(screenPos.x, screenPos.y + 55f);
        }

        public void Release()
        {
            m_Owner = default;
            Dispose();
        }
    }
}