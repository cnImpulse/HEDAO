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
        private List<int> LevelList = new List<int> { 1, 2, 3, 4 };
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            View.m_select_list.numItems = LevelList.Count;
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void RenderListItem(int index, GObject obj)
        {
            obj.asButton.title = LevelList[index].ToString();
        }
    }
}