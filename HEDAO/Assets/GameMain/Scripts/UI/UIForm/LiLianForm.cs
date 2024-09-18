using System.Collections;
using System.Collections.Generic;
using Cfg;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class LiLianForm : FGUIForm<FGUILiLianForm>
    {
        private ProcedureLiLian Owner;
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
    
            Owner = userData as ProcedureLiLian;
            
            View.m_list_task.m_list.itemRenderer = OnRenderTask;
            View.m_list_task.m_btn_go.onClick.Set(OnClickGo);
            // View.m_list_task.m_ctrl_select.selectedIndex = -1;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            View.m_list_team.Refresh();

            View.m_txt_info.text = "选择目的地";

            // View.m_list_task.m_list.numItems = Building.Count;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void OnRenderTask(int index, GObject item)
        {
            item.asButton.title = "解救清风村";
            item.asButton.onClick.Add(() => { OnClickTask(index); });
        }

        public void OnClickTask(int index)
        {
            // var girdUnit = GameEntry.Entity.GetEntity(Building[index].Id);
            //
            // GameEntry.Camera.VirtualCamera.Follow = girdUnit.transform;
            //
            // GameEntry.Effect.ShowEffect(GameEntry.Cfg.Effect.Select, girdUnit.transform.position, true);
        }

        public void OnClickGo()
        {
            var index = View.m_list_task.m_list.selectedIndex;
            if (index < 0)
            {
                return;
            }
            
            GameEntry.Effect.HideEffect(GameEntry.Cfg.Effect.Select);

            // var data = Building[index];
            // Owner.StartLiLian(data.GridPos);
            Close();
        }
    }
}