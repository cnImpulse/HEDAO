using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class ActionForm : FGUIForm<FGUIActionForm>
    {
        private ActionState m_Owner = null;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_panel_action.m_list_action.itemRenderer = RenderListItem;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Owner = userData as ActionState;
            View.m_panel_action.m_list_action.numItems = 2;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void RenderListItem(int index, GObject obj)
        {
            var item = obj as GButton;
            if (index == 0)
            {
                item.title = "技能";
                item.onClick.Add(() => { m_Owner.SelectAction(ActionType.Skill); });
            }
            else if (index == 1)
            {
                item.title = "待机";
                item.onClick.Add(() => { m_Owner.SelectAction(ActionType.Await); });
            }
        }
    }
}