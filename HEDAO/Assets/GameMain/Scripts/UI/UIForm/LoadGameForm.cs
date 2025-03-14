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
                item.m_btn_clear.onClick.Set(() => { GameEntry.Save.DeleteData(index); RenderListItem(index, obj); });
            }
            else
            {
                item.m_btn_load.title = "empty";
            }

            item.m_btn_load.onClick.Set(() => { OnClickLoad(index); });
        }

        private void OnClickLoad(int index)
        {
            GameEntry.Save.LoadGame(index);
            GameEntry.UI.CloseUIForm(UIName.MenuForm);
            GameEntry.Event.Fire(this, EventName.StartGame);

            Close();
        }
    }
}