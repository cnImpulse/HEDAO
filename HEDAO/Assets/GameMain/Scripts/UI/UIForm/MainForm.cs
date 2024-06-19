using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class MainForm : FGUIForm<FGUIMainForm>
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_list_building.m_list.itemRenderer = RenderListItem;
            View.m_btn_disciple.onClick.Set(OnClickDisciple);
            View.m_btn_go.onClick.Set(OnClickGo);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void OnClickDisciple()
        {
            GameEntry.UI.OpenUIForm(UIFromName.DiscipleForm);
        }

        private void OnClickGo()
        {
            GameEntry.UI.OpenUIForm(UIFromName.PrepareForm);
            Close();
        }

        private void RenderListItem(int index, GObject obj)
        {
            
        }
    }
}