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
                qiudao.m_list_role.m_list.numItems = 3;

                var ctrl = qiudao.m_list_role.m_ctrl_select;
                ctrl.ClearPages();
                for (int i = 0; i < 3; i++)
                {
                    ctrl.AddPage("");
                }
                ctrl.selectedIndex = 0;
            }
        }
    }
}