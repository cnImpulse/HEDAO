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

        public HashSet<long> RoleTeamSet => GameMgr.Save.Data.RoleTeamSet;
        public Dictionary<long, Role> DiscipleDict => GameMgr.Save.Data.DiscipleList;

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
            item.onClick.Set(() => OnClickRole(role.Id));
        }

        private void OnRenderTeamRole(int index, GObject obj, object data)
        {
            var role = data as Role;
            var item = obj as FGUIBtnRole;
            item.Refresh(role);
            item.onClick.Set(() => OnClickRole(role.Id));
        }

        private void OnClickRole(long roleId)
        {
            if (RoleTeamSet.Contains(roleId))
            {
                RoleTeamSet.Remove(roleId);
            }
            else
            {
                RoleTeamSet.Add(roleId);
            }

            RefreshList();
        }

        public void RefreshList()
        {
            m_RoleList = DiscipleDict.Values.Where((role) => { return !RoleTeamSet.Contains(role.Id); }).AsEnumerable<object>().ToList();
            m_TeamList = RoleTeamSet.Select((id) => { return DiscipleDict[id]; }).AsEnumerable<object>().ToList();

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