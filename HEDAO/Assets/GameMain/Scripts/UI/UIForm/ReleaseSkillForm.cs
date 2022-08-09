using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class ReleaseSkillForm : FGUIForm<FGUIActionForm>
    {
        private SkillState m_Owner = null;

        public GList actionList => View.m_panel_action.m_list_action;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            actionList.defaultItem = FGUISkillItem.URL;
            actionList.itemRenderer = RenderListItem;

            
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_Owner = userData as SkillState;
            View.m_btn_cancel.onClick.Add(m_Owner.CancelAction);

            actionList.numItems = 2;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            View.m_btn_cancel.onClick.Clear();

            base.OnClose(isShutdown, userData);
        }

        private void RenderListItem(int index, GObject obj)
        {
            var item = obj as GButton;
            item.onClick.Add(() => { OnClickSkillBtn(index); });
        }

        private void OnClickSkillBtn(int index)
        {
            Log.Info("请求释放技能: {0}", index);
            m_Owner.ReqReleaseSkill(index);
        }
    }
}