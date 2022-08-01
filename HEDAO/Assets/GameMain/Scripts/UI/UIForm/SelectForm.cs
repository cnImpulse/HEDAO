using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class SelectForm : FGUIForm<FGUISelectForm>
    {
        private List<int> m_CanSelectRoleList = new List<int> { 1 };

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_list.itemRenderer = RenderListItem;
            View.m_list.opaque = false;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            View.m_btn_check.onClick.Add(() => { View.m_list.SelectNone(); });
            View.m_btn_return.onClick.Add(OnClickReturn);
            View.m_btn_sure.onClick.Add(OnClickSure);

            View.m_list.numItems = m_CanSelectRoleList.Count;
            View.m_list.ResizeToFit();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void RenderListItem(int index, GObject obj)
        {
            var id = m_CanSelectRoleList[index];
            var roleData = GameEntry.Cfg.Tables.TbRoleCfg.GetOrDefault(id);
            if (roleData != null)
            {
                var item = obj as FGUIRoleItem;
                item.m_panel_role.m_txt_name.text = roleData.Name;
                item.m_panel_role.m_txt_hp.text = roleData.BaseAttribute.MaxHP.ToString();
                item.m_panel_role.m_txt_qi.text = roleData.BaseAttribute.MaxQI.ToString();
            }
        }

        private void OnClickReturn()
        {
            GameEntry.UI.OpenUIForm(UIFromName.MenuForm);
            Close();
        }

        private void OnClickSure()
        {
            int index = View.m_list.selectedIndex;
            if (index < 0)
            {
                Log.Info("选择一名开局角色。");
                return;
            }

            GameEntry.Save.SaveData.RoleList.Add(m_CanSelectRoleList[index]);
            GameEntry.Event.Fire(this, EventName.StartGame);
            Close();
        }
    }
}