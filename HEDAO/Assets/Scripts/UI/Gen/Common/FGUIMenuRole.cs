/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIMenuRole : GComponent
    {
        public FGUIRadarWidget m_rader;
        public GButton m_btn_close;
        public GLabel m_txt_role;
        public GButton m_btn_remove;
        public const string URL = "ui://rt51n0kjrnio61";

        public static FGUIMenuRole CreateInstance()
        {
            return (FGUIMenuRole)UIPackage.CreateObject("Common", "MenuRole");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_rader = (FGUIRadarWidget)GetChild("rader");
            m_btn_close = (GButton)GetChild("btn_close");
            m_txt_role = (GLabel)GetChild("txt_role");
            m_btn_remove = (GButton)GetChild("btn_remove");
        }
    }
}