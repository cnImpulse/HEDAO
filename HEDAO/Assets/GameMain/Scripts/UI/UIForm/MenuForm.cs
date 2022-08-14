using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class MenuForm : FGUIForm<FGUIMenuForm>
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_btn_start.onClick.Add(() => { GameEntry.UI.OpenUIForm(UIFromName.LoadGameForm); });
            View.m_btn_exit.onClick.Add(() => { Log.Info("退出游戏。"); });
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
        }
    }
}