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
            var attr = role.BattleAttr;
            var info = $"姓名：{role.Name}\n";
            info += $"年龄：{attr.GetAttr(EAttrType.Age)} 寿命：{attr.GetAttr(EAttrType.Life)}\n";

            var attrList = GameMgr.Cfg.Tables.TbMisc.AttrTypeList;
            for (int i = 0; i < attrList.Count; i++)
            {
                var attrType= attrList[i];
                info += $"{attrType.GetName()}：{attr.GetAttr(attrType)} ";
                if (i % 2 == 1)
                {
                    info += '\n';
                }
            }

            m_text_role.text = info;
            m_rader.Refresh(role);
        }
    }
}