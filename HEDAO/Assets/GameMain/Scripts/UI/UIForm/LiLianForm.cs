using System.Collections;
using System.Collections.Generic;
using Cfg;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;
using System.Linq;

namespace HEDAO
{
    public class LiLianForm : FGUIForm<FGUILiLianForm>
    {
        private ProcedureLiLian Owner;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
    
            Owner = userData as ProcedureLiLian;
            
            View.m_panel_task.m_btn_go.onClick.Set(OnClickGo);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            View.m_list_team.Refresh();
            RefreshTaskPanel(0);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        public void RefreshTaskPanel(int index)
        {
        }

        public void OnClickGo()
        {
            View.m_panel_task.visible = false;

            GameEntry.UI.OpenUIForm(UIName.MenuActionSelect);
        }
    }
}