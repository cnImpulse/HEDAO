using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;
using HEDAO;

namespace FGUI.CommonUI
{
    public partial class FGUIDangMoPage : GComponent
    {
        private List<Role> m_RoleList;
        private List<Role> m_TeamList;

        public void RefreshPage()
        {
            m_RoleList = GameEntry.Save.PlayerData.DiscipleList.Select((pair) => pair.Value).ToList();
            
            var ctrl = m_list_role.m_ctrl_select;
            m_list_role.m_list.itemRenderer = OnRenderRole;
            m_list_role.m_list.numItems = m_RoleList.Count;

            for (int i = 0; i < 3; i++)
            {
                ctrl.AddPage("");
            }
            ctrl.selectedIndex = 0;

            RefreshTeamList();
        }

        public void RefreshTeamList()
        {
            m_TeamList = new List<Role>();
            m_list_team.m_list.itemRenderer = OnRenderTeamRole;
            m_list_team.m_list.numItems = 4;
        }
        
        private void OnRenderRole(int index, GObject obj)
        {
            var role = m_RoleList[index];
            obj.asButton.title = role.Name;
        }

        private void OnRenderTeamRole(int index, GObject obj)
        {
            if (m_TeamList.Count <= index)
            {
                obj.asLabel.title = "空缺";
            }
            else
            {
                var role = m_TeamList[index];
                obj.asButton.title = role.Name;
            }
        }
    }
}