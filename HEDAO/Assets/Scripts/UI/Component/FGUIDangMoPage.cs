using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIDangMoPage : GComponent
    {
        private List<object> m_RoleList = new List<object>();
        private List<object> m_TeamList = new List<object>();

        public Dictionary<long, Role> TeamDict => GameMgr.Save.Data.TeamDict;
        public Dictionary<long, Role> RoleDict => GameMgr.Save.Data.RoleDict;

        public void OnInit()
        {
            m_list_role.m_list.itemRenderer = OnRenderRole;
            m_list_team.m_list.itemRenderer = OnRenderTeamRole;
            m_panel_task.m_btn_go.onClick.Set(OnClickGo);
        }

        private void OnClickGo()
        {
            GameMgr.Explore.StartExplore();
        }

        private void OnRenderRole(int index, GObject obj, object data)
        {
            var role = data as Role;
            var item = obj as FGUIBtnRole;
            item.Refresh(role);
            item.onClick.Set(() => OnClickRole(role));
        }

        private void OnRenderTeamRole(int index, GObject obj, object data)
        {
            var role = data as Role;
            var item = obj as FGUIBtnRole;
            item.Refresh(role);
            item.onClick.Set(() => OnClickRole(role));
        }

        private void OnClickRole(Role role)
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
            m_RoleList = RoleDict.Values.Where((role) => { return !TeamDict.ContainsKey(role.Id); }).AsEnumerable<object>().ToList();
            m_TeamList = TeamDict.Keys.Select((id) => { return RoleDict[id]; }).AsEnumerable<object>().ToList();

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