using System;
using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIDangMoPage : GComponent
    {
         public HashSet<long> RoleTeamSet => GameMgr.Save.Data.RoleTeamSet;
         public Dictionary<long, Role> DiscipleList => GameMgr.Save.Data.DiscipleList;

        public void OnInit()
        {
            m_list_role.m_list.itemRenderer = OnRenderRole;
            m_list_team.m_list.itemRenderer = OnRenderRole;
        }

        private void OnRenderRole(int index, GObject item, object data)
        {
            var role = data as Role;
            item.asButton.title = role.Name;
        }

        public void RefreshPage()
        {
            OnInit();

            m_list_role.m_list.RefreshList(DiscipleList.Values.AsEnumerable<object>().ToList());
        } 
    }
}