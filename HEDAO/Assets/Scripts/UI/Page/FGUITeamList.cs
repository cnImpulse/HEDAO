using System.Collections.Generic;
using System.Linq;
using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUITeamList : GComponent
    {
        // private List<Role> m_TeamList;
        // public HashSet<int> RoleTeamSet => GameEntry.Save.PlayerData.RoleTeamSet;
        // public Dictionary<int, Role> DiscipleList => GameEntry.Save.PlayerData.DiscipleList;
        //
        // public void OnInit()
        // {
        //
        // }
        //
        // public void Refresh()
        // {
        //     m_TeamList = RoleTeamSet.Select(id => DiscipleList[id]).ToList();
        //     m_list.itemRenderer = OnRenderTeamRole;
        //     m_list.numItems = 4;
        // }
        //
        // private void OnRenderTeamRole(int index, GObject obj)
        // {
        //     if (m_TeamList.Count <= index)
        //     {
        //         obj.asLabel.title = "空缺";
        //     }
        //     else
        //     {
        //         var role = m_TeamList[index];
        //         obj.asLabel.title = role.Name;
        //     }
        // }
    }
}