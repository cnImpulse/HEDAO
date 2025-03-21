/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIMainForm : GComponent
    {
        public Controller m_ctrl_page;
        public GList m_list_building;
        public GList m_list_page;
        public const string URL = "ui://rt51n0kjmv3555";

        public static FGUIMainForm CreateInstance()
        {
            return (FGUIMainForm)UIPackage.CreateObject("Common", "MainForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_ctrl_page = GetController("ctrl_page");
            m_list_building = (GList)GetChild("list_building");
            m_list_page = (GList)GetChild("list_page");
        }
    }
}