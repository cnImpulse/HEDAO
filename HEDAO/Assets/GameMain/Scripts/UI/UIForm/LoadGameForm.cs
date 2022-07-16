using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class LoadGameForm : FGUIForm<FGUILoadGame>
    {
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_btn_close.onClick.Add(() => { Close(); });
            View.m_list.RemoveChildren();
            View.m_list.itemRenderer = RenderListItem;
            View.m_list.numItems = 3;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
        }

        private void RenderListItem(int index, GObject obj)
        {
            var item = obj as FGUISaveItem;
            if (GameEntry.Save.HasData(index))
            {
                item.m_btn_load.title = GameEntry.Save.GetSaveName(index);
            }

            item.m_btn_load.onClick.Add(() => { OnClickLoad(index); });
        }

        private void OnClickLoad(int index)
        {
            GameEntry.Save.LoadGame(index);
            GameEntry.UI.CloseUIForm(UIFromName.MenuForm);
            if (GameEntry.Save.HasData(index))
            {
                GameEntry.Event.Fire(this, EventName.StartGame);
            }
            else
            {
                GameEntry.UI.OpenUIForm(UIFromName.SelectForm);
            }

            Close();
        }
    }
}