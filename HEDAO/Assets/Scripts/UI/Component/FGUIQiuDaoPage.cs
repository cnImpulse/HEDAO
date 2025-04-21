using System.Collections.Generic;
using System.Linq;
using Cfg;
using FairyGUI;
using UnityEngine;

namespace FGUI.Common
{
    public partial class FGUIQiuDaoPage : GComponent
    {
        private List<PlayerRole> m_RoleList;
        public int MaxRoleNum = 3;

        public void Refresh()
        {
            m_btn_get.asButton.onClick.Set(() => { OnClickBtnGet(); });

            m_RoleList = GameMgr.Save.Data.RecruitList;
            visible = m_RoleList.Count != 0;
            if (m_RoleList.Count == 0)
            {
                return;
            }

            var ctrl = m_list_role.m_ctrl_select;
            ctrl.ClearPages();
            ctrl.onChanged.Set(OnRoleChanged);

            m_list_role.m_list.itemRenderer = OnRenderRole;
            m_list_role2.m_list.itemRenderer = OnRenderRole2;

            RefreshRoleList();
        }

        private void OnRenderRole(int index, GObject obj, object data)
        {
            var role = data as Role;
            var item = obj as FGUIBtnRole;
            item.Refresh(role);
        }

        private void OnRenderRole2(int index, GObject obj, object data)
        {
            var role = data as Role;
            var item = obj as FGUIBtnRole;
            item.mode = ButtonMode.Common;
            item.Refresh(role);
        }

        private void OnClickBtnGet()
        {
            var selectIndex = m_list_role.m_ctrl_select.selectedIndex;
            if (selectIndex < 0)
            {
                return;
            }

            if (GameMgr.Save.Data.RoleDict.Count >= MaxRoleNum)
            {
                return;
            }

            var role = m_RoleList[selectIndex];
            GameMgr.Save.Data.RoleDict.Add(role.Id, role);

            m_RoleList.RemoveAt(selectIndex);
            RefreshRoleList();
        }

        private void RefreshRoleList()
        {
            m_list_role.m_list.RefreshList(m_RoleList.ToList());

            var list = GameMgr.Save.Data.RoleDict.Values.ToList();
            m_list_role2.m_list.RefreshList(list);
            m_txt_role_num.text = string.Format("{0}/{1}", list.Count, MaxRoleNum);
        }

        private void OnRoleChanged()
        {
            var selectIndex = m_list_role.m_ctrl_select.selectedIndex;
            if (selectIndex < 0)
            {
                return;
            }

            var role = m_RoleList[selectIndex];
            m_text_role.text = RoleUtil.GetRoleInfo(role, false);
            m_rader.Refresh(role);
        }
    }
}