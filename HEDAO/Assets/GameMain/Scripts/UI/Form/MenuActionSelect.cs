using System;
using UnityEngine;
using FairyGUI;
using FGUI.CommonUI;
using System.Collections.Generic;

namespace HEDAO
{
    public class MenuActionSelect : FGUIForm<FGUIMenuActionSelect>
    {
        private List<ActionNodeBase> ActionList = new List<ActionNodeBase>();

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_list_action.itemRenderer = OnItemRender;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            ActionList.Add(new BattleNode(10000));
            //ActionList.Add(new TownNode());

            View.m_list_action.numItems = ActionList.Count;
        }
            
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
    
        }

        private void OnItemRender(int index, GObject item)
        {
            var node = ActionList[index];
            item.asButton.text = node.Cfg.Name;
            item.asButton.GetChild("txt_desc").text = node.Cfg.Desc;

            item.asButton.onClick.Set(node.Action);
        }
    }
}
    