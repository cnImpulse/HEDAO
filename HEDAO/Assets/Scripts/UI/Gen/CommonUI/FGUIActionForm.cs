/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIActionForm : GComponent
    {
        public GButton m_btn_cancel;
        public FGUIActionPanel m_panel_action;
        public const string URL = "ui://rt51n0kjuyzr4r";

        public static FGUIActionForm CreateInstance()
        {
            return (FGUIActionForm)UIPackage.CreateObject("CommonUI", "ActionForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_cancel = (GButton)GetChild("btn_cancel");
            m_panel_action = (FGUIActionPanel)GetChild("panel_action");
        }
    }
}