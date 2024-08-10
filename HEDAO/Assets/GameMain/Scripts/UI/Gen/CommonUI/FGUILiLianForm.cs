/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUILiLianForm : GComponent
    {
        public GTextField m_txt_info;
        public FGUITeamList m_list_team;
        public const string URL = "ui://rt51n0kjlvkb5b";

        public static FGUILiLianForm CreateInstance()
        {
            return (FGUILiLianForm)UIPackage.CreateObject("CommonUI", "LiLianForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_txt_info = (GTextField)GetChild("txt_info");
            m_list_team = (FGUITeamList)GetChild("list_team");
        }
    }
}