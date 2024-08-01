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

        public HashSet<int> RoleTeamSet => GameEntry.Save.PlayerData.RoleTeamSet;
        public Dictionary<int, Role> DiscipleList => GameEntry.Save.PlayerData.DiscipleList;

        public void OnCreat()
        {
            m_btn_go.onClick.Set(OnClickBtnGo);
            m_btn_add.onClick.Set(OnClickBtnAddOrRemove);
        }
        
        public void RefreshPage()
        {
            m_RoleList = DiscipleList.Select((pair) => pair.Value).ToList();
            
            var ctrl = m_list_role.m_ctrl_select;
            ctrl.onChanged.Add(() => { OnRoleChanged();});

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
            m_TeamList = RoleTeamSet.Select(id => DiscipleList[id]).ToList();
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
                obj.asLabel.title = role.Name;
            }
        }

        private Role GetSelectedRole()
        {
            var selectIndex = m_list_role.m_ctrl_select.selectedIndex;
            if (selectIndex < 0)
            {
                return null;
            }

            return m_RoleList[selectIndex];
        }
        
        public void OnClickBtnAddOrRemove()
        {
            var role = GetSelectedRole();
            if (role == null)
            {
                return;    
            }
            
            if (RoleTeamSet.Contains(role.Id))
            {
                RoleTeamSet.Remove(role.Id);
            }
            else
            {
                RoleTeamSet.Add(role.Id);
            }

            RefreshTeamList();
            OnRoleChanged();
        }
        
        public void OnClickBtnGo()
        {
            GameEntry.Event.Fire(this, EventName.StartAdventure);
        }
        
        private void OnRoleChanged()
        {
            var role = GetSelectedRole();
            m_btn_add.visible = role != null;
            if (role != null)
            {
                m_btn_add.title = RoleTeamSet.Contains(role.Id) ? "退出" : "加入";
            }
        }
    }
}