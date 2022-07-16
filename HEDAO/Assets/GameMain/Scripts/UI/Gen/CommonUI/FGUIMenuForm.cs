/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIMenuForm : GComponent
    {
        public GButton m_btn_start;
        public GButton m_btn_exit;
        public const string URL = "ui://rt51n0kjdsjm0";

        public static FGUIMenuForm CreateInstance()
        {
            return (FGUIMenuForm)UIPackage.CreateObject("CommonUI", "MenuForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_start = (GButton)GetChild("btn_start");
            m_btn_exit = (GButton)GetChild("btn_exit");
        }
    }
}