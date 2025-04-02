/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIDangMoPage : GComponent
    {
        public FGUIVerticalList m_list_role;
        public FGUITeamList m_list_team;
        public FGUITaskWidget m_panel_task;
        public const string URL = "ui://rt51n0kjoq905k";

        public static FGUIDangMoPage CreateInstance()
        {
            return (FGUIDangMoPage)UIPackage.CreateObject("Common", "DangMoPage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_role = (FGUIVerticalList)GetChild("list_role");
            m_list_team = (FGUITeamList)GetChild("list_team");
            m_panel_task = (FGUITaskWidget)GetChild("panel_task");
        }
    }
}