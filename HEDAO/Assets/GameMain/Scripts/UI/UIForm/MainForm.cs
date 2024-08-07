using System.Collections;
using System.Collections.Generic;
using Cfg;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class MainForm : FGUIForm<FGUIMainForm>
    {
        private List<Role> m_RoleList;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_list_building.itemRenderer = RenderListItem;
            View.m_ctrl_page.onChanged.Add(RefreshPage);
            //View.m_btn_disciple.onClick.Set(OnClickDisciple);
            //View.m_btn_go.onClick.Set(OnClickGo);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            var buildingCount = GameEntry.Cfg.Tables.TbBuildingCfg.DataList.Count;
            View.m_list_building.numItems = buildingCount;

            View.m_ctrl_page.ClearPages();
            for (int i = 0;i < buildingCount; i++)
            {
                View.m_ctrl_page.AddPage("");
            }
            View.m_ctrl_page.selectedIndex = 0;
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
            var cfg = GameEntry.Cfg.Tables.TbBuildingCfg.DataList[index];
            obj.asButton.title = cfg.Name;
        }

        private void RefreshPage()
        {
            var index = View.m_ctrl_page.selectedIndex;
            var page = View.m_list_page.GetChildAt(index);
            if (index == 0)
            {
                var qiudao = page as FGUIQiuDaoPage;
                m_RoleList = RandomGenRole(3);

                var ctrl = qiudao.m_list_role.m_ctrl_select;
                ctrl.ClearPages();
                ctrl.onChanged.Clear();
                ctrl.onChanged.Add(() => { OnRoleChanged(qiudao);});
                
                qiudao.m_list_role.m_list.itemRenderer = OnRenderRole;
                qiudao.m_list_role.m_list.numItems = m_RoleList.Count;

                for (int i = 0; i < 3; i++)
                {
                    ctrl.AddPage("");
                }
                ctrl.selectedIndex = 0;
            }
        }

        private void OnRenderRole(int index, GObject obj)
        {
            var role = m_RoleList[index];
            obj.asButton.title = role.Name;
        }

        private void OnRoleChanged(FGUIQiuDaoPage QiuDaoPage)
        {
            var selectIndex = QiuDaoPage.m_list_role.m_ctrl_select.selectedIndex;
            if (selectIndex < 0)
            {
                return;
            }
            
            var role = m_RoleList[selectIndex];
            var info = $"姓名：{role.Name}\n";
            info += $"年龄：{role.BattleAttr.GetAttr(EAttrType.Age)} 寿命：{role.BattleAttr.GetAttr(EAttrType.Life)}\n";

            QiuDaoPage.m_text_role.text = info;

            float[] arr = new float[5];
            foreach (var pair in role.WuXin)
            {
                var index = (int)pair.Key;
                var value = pair.Value / 100f;
                arr[index] = value;
                var text = QiuDaoPage.m_rader.GetChildAt(
                    QiuDaoPage.m_rader.GetChildIndex(QiuDaoPage.m_rader.m_text_wuxin_0) + index);
                text.text = $"{pair.Key.GetName()}：{pair.Value}";
            }
            
            QiuDaoPage.m_rader.m_img_wuxing.shape.DrawRegularPolygon(5, 4, Color.white, 
                Color.black, Color.white, 54, arr);
        }

        private List<Role> RandomGenRole(int count)
        {
            var ret = new List<Role>(count);
            for (int i = 0; i < count; i++)
            {
                ret.Add(new Role());
            }

            return ret;
        }
    }
}