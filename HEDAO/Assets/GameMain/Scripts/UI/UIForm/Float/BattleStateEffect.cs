using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class BattleStateEffect : FGUIForm<FGUIBattleStateEffect>
    {
        private RoundStartState m_Owner = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Owner = userData as RoundStartState;

            var activeCamp = m_Owner.BattleData.ActiveCamp;
            View.text = BattleUtl.GetText(activeCamp, BattleUtl.GetCampText(activeCamp) + "回合");
            View.m_anim.Play(() => {
                m_Owner.ChangeState<BattleUnitSelectState>();
                Close();
            });
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }
    }
}