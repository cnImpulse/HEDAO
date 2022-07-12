using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public class MenuForm : FGUIForm<FGUIMenu>
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_btn_new.onClick.Add(OnClickStart);
            View.m_btn_lod.onClick.Add(() => { Log.Info("读取存档。"); });
            View.m_btn_exit.onClick.Add(() => { Log.Info("退出游戏。"); });
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
        }

        private void OnClickStart()
        {
            GameEntry.Event.Fire(this, EventName.StartGame);
            Close();
        }
    }
}