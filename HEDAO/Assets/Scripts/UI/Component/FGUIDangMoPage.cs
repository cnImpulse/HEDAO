using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIDangMoPage : GComponent
    {
        private List<PlayerRole> m_RoleList = null;
        private List<PlayerRole> m_TeamList = null;

        public Dictionary<long, PlayerRole> TeamDict => GameMgr.Save.Data.TeamDict;
        public Dictionary<long, PlayerRole> RoleDict => GameMgr.Save.Data.RoleDict;

        public void OnInit()
        {
            m_list_role.m_list.itemRenderer = OnRenderRole;
            m_list_team.m_list.itemRenderer = OnRenderRole;
            m_panel_task.m_btn_go.onClick.Set(OnClickGo);
        }

        private void OnClickGo()
        {
            GameMgr.Explore.StartExplore();
        }

        private void OnRenderRole(int index, GObject obj, object data)
        {
            var role = data as PlayerRole;
            var item = obj as FGUIBtnRole;
            item.mode = ButtonMode.Common;
            item.Refresh(role);
            item.onClick.Set(() => OnClickRole(role));
        }
        
        private void OnClickRole(PlayerRole role)
        {
            if (TeamDict.ContainsKey(role.Id))
            {
                TeamDict.Remove(role.Id);
            }
            else
            {
                TeamDict.Add(role.Id, role);
            }

            RefreshList();
        }

        public void RefreshList()
        {
            m_RoleList = RoleDict.Values.Where((role) => { return !TeamDict.ContainsKey(role.Id); }).ToList();
            m_TeamList = TeamDict.Keys.Select((id) => { return RoleDict[id]; }).ToList();

            m_list_role.m_list.RefreshList(m_RoleList);
            m_list_team.m_list.RefreshList(m_TeamList);
        }

        public void Refresh()
        {
            OnInit();

            RefreshList();
        }
    }
}