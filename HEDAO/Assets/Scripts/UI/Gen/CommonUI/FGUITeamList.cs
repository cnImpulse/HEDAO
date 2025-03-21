/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUITeamList : GComponent
    {
        public GList m_list;
        public const string URL = "ui://rt51n0kju7915m";

        public static FGUITeamList CreateInstance()
        {
            return (FGUITeamList)UIPackage.CreateObject("CommonUI", "TeamList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list = (GList)GetChild("list");
        }
    }
}