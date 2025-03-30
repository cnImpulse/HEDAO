using System.Collections.Generic;
using System.Linq;
using Cfg;
using FairyGUI;
using UnityEngine;

namespace FGUI.Common
{
    public partial class FGUIQiuDaoPage : GComponent
    {
        private List<Role> m_RoleList;

        public void Refresh()
        {
            m_btn_get.asButton.onClick.Set(() => { OnClickBtnGet(); });

            m_RoleList = GameMgr.Save.Data.RandomRoleList;
            visible = m_RoleList.Count != 0;
            if (m_RoleList.Count == 0)
            {
                return;
            }

            var ctrl = m_list_role.m_ctrl_select;
            ctrl.ClearPages();
            ctrl.onChanged.Set(() => { OnRoleChanged(); });

            m_list_role.m_list.itemRenderer = OnRenderRole;
            RefreshRoleList();
        }

        private void OnRenderRole(int index, GObject obj, object data)
        {
            var role = m_RoleList[index];
            var item = obj as FGUIBtnRole;
            item.Refresh(role);
            item.onClick.Set(() => {
                m_list_role.m_ctrl_select.selectedIndex = index; });
        }

        private void OnClickBtnGet()
        {
            var selectIndex = m_list_role.m_ctrl_select.selectedIndex;
            if (selectIndex < 0)
            {
                return;
            }

            var role = m_RoleList[selectIndex];
            GameMgr.Save.Data.DiscipleList.Add(role.Id, role);

            m_RoleList.RemoveAt(selectIndex);
            RefreshRoleList();
        }

        private void RefreshRoleList()
        {
            m_list_role.m_list.numItems = m_RoleList.Count;
            if (m_RoleList.Count == 0) return;

            var ctrl = m_list_role.m_ctrl_select;
            ctrl.ClearPages();
            for (int i = 0; i < m_RoleList.Count; i++)
            {
                ctrl.AddPage("");
            }
            ctrl.selectedIndex = 0;
        }
        
        private void OnRoleChanged()
        {
            var selectIndex = m_list_role.m_ctrl_select.selectedIndex;
            if (selectIndex < 0)
            {
                return;
            }

            var role = m_RoleList[selectIndex];
            m_text_role.text = RoleUtil.GetRoleInfo(role);
            m_rader.Refresh(role);
        }
    }
}