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
            
            View.m_btn_battle.onClick.Add(() =>
            {
                GameEntry.Save.LoadGame(1);
                GameEntry.Save.PlayerData.RoleList = new List<int>{ 1001, 1002, 1003 };
                GameEntry.Event.Fire(this, EventName.StartBattle);
            });
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
        }
    }
}