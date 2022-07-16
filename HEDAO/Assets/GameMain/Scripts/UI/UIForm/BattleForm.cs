using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class BattleForm : FGUIForm<FGUIBattleForm>
    {
        private BattleStartState m_Owner = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_btn_start.onClick.Add(OnClickStart);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Owner = userData as BattleStartState;

            View.m_btn_start.visible = true;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void OnClickStart()
        {
            //View.m_btn_start.visible = false;
            m_Owner.StartBattle();
        }
    }
}