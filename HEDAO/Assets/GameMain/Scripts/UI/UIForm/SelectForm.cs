using System.Collections;
using System.Collections.Generic;
using Cfg;
using UnityEngine;
using FGUI.CommonUI;
using UnityGameFramework.Runtime;
using FairyGUI;

namespace HEDAO
{
    public class SelectForm : FGUIForm<FGUISelectForm>
    {
        private List<int> m_CanSelectRoleList = new List<int> { 1001};

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);

            View.m_list.itemRenderer = RenderListItem;
            View.m_list.opaque = false;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            View.m_btn_check.onClick.Add(() => { View.m_list.SelectNone(); });
            View.m_btn_return.onClick.Add(OnClickReturn);
            View.m_btn_sure.onClick.Add(OnClickSure);

            View.m_list.numItems = m_CanSelectRoleList.Count;
            View.m_list.ResizeToFit();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        private void RenderListItem(int index, GObject obj)
        {
            var id = m_CanSelectRoleList[index];
            var roleData = GameEntry.Cfg.Tables.TbCharacter.GetOrDefault(id);
            if (roleData != null)
            {
                var item = obj as FGUIRoleItem;
                item.m_panel_role.m_txt_name.text = roleData.Name;
                item.m_panel_role.m_txt_hp.text = roleData.BaseAttr[EAttrType.MaxHP].ToString();
                item.m_panel_role.m_txt_qi.text = roleData.BaseAttr[EAttrType.MaxQI].ToString();
            }
        }

        private void OnClickReturn()
        {
            GameEntry.UI.OpenUIForm(UIName.MenuForm);
            Close();
        }

        private void OnClickSure()
        {
            var list = View.m_list.GetSelection();
            if (list.Count == 0)
            {
                Log.Info("至少选择一名开局角色。");
                return;
            }

            GameEntry.Save.PlayerData.RoleList.AddRange(list.ConvertAll((input) => { return m_CanSelectRoleList[input]; }));
            GameEntry.Event.Fire(this, EventName.StartGame);
            Close();
        }
    }
}