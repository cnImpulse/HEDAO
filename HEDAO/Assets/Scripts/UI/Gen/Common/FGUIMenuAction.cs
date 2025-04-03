/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIMenuAction : GComponent
    {
        public GButton m_btn_check;
        public FGUIActionPanel m_panel_action;
        public const string URL = "ui://rt51n0kjuyzr4r";

        public static FGUIMenuAction CreateInstance()
        {
            return (FGUIMenuAction)UIPackage.CreateObject("Common", "MenuAction");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_check = (GButton)GetChild("btn_check");
            m_panel_action = (FGUIActionPanel)GetChild("panel_action");
        }
    }
}