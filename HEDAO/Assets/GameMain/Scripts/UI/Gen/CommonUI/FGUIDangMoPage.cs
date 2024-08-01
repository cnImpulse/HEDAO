/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIDangMoPage : GComponent
    {
        public FGUIVerticalList m_list_role;
        public GButton m_btn_go;
        public FGUITeamList m_list_team;
        public const string URL = "ui://rt51n0kjoq905k";

        public static FGUIDangMoPage CreateInstance()
        {
            return (FGUIDangMoPage)UIPackage.CreateObject("CommonUI", "DangMoPage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_role = (FGUIVerticalList)GetChild("list_role");
            m_btn_go = (GButton)GetChild("btn_go");
            m_list_team = (FGUITeamList)GetChild("list_team");
        }
    }
}