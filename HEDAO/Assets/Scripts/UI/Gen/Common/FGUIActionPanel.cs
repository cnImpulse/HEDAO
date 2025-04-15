/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIActionPanel : GComponent
    {
        public Controller m_ctrl_select;
        public GTextField m_title;
        public GList m_list_action;
        public GLabel m_txt_info;
        public const string URL = "ui://rt51n0kjuyzr4t";

        public static FGUIActionPanel CreateInstance()
        {
            return (FGUIActionPanel)UIPackage.CreateObject("Common", "ActionPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_ctrl_select = GetController("ctrl_select");
            m_title = (GTextField)GetChild("title");
            m_list_action = (GList)GetChild("list_action");
            m_txt_info = (GLabel)GetChild("txt_info");
        }
    }
}