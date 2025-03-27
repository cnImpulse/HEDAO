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
            m_list_role.m_list.numItems = m_RoleList.Count;

            for (int i = 0; i < m_RoleList.Count; i++)
            {
                ctrl.AddPage("");
            }
            ctrl.selectedIndex = 0;
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
            m_list_role.m_ctrl_select.selectedIndex = 0;
            m_list_role.m_list.numItems = m_RoleList.Count;
        }

        private static List<EAttrType> AttrList = new List<EAttrType>()
        {
            EAttrType.MaxHP, EAttrType.MaxQI, EAttrType.SPD, EAttrType.STR,
            EAttrType.TPO, EAttrType.SSI, EAttrType.FAS
        };
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
            foreach (var attrType in AttrList)
            {
                info += $"{attrType.GetName()}：{attr.GetAttr(attrType)} \n";
            }

            m_text_role.text = info;

            float[] arr = new float[5];
            foreach (var pair in role.WuXin)
            {
                var index = (int)pair.Key;
                var value = pair.Value / 100f;
                arr[index] = value;
                var text = m_rader.GetChildAt(
                    m_rader.GetChildIndex(m_rader.m_text_wuxin_0) + index);
                text.text = $"{pair.Key.GetName()}：{pair.Value}";
            }

            m_rader.m_img_wuxing.shape.DrawRegularPolygon(5, 4, Color.white,
                Color.black, Color.white, 54, arr);
        }
    }
}