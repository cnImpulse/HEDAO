using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class PrepareForm : FGUIForm<FGUIPrepareForm>
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_list_team.itemRenderer = RenderListItem;
            View.m_btn_return.onClick.Set(OnClickReturn);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            View.m_list_team.numItems = 4;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void RenderListItem(int index, GObject obj)
        {
            var item = obj.asButton;
            item.title = "Пе";
        }

        private void OnClickReturn()
        {
            GameEntry.UI.OpenUIForm(UIFromName.MainForm);
            Close();
        }
    }
}