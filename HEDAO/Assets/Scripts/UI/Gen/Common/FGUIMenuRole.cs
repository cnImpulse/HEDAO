/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIMenuRole : GComponent
    {
        public FGUICompRole m_comp_role;
        public GLabel m_txt_attr;
        public GLabel m_txt_skill;
        public GGroup m_info;
        public FGUICompStore m_comp_store;
        public FGUIRadarWidget m_rader;
        public GButton m_btn_close;
        public const string URL = "ui://rt51n0kjrnio61";

        public static FGUIMenuRole CreateInstance()
        {
            return (FGUIMenuRole)UIPackage.CreateObject("Common", "MenuRole");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_comp_role = (FGUICompRole)GetChild("comp_role");
            m_txt_attr = (GLabel)GetChild("txt_attr");
            m_txt_skill = (GLabel)GetChild("txt_skill");
            m_info = (GGroup)GetChild("info");
            m_comp_store = (FGUICompStore)GetChild("comp_store");
            m_rader = (FGUIRadarWidget)GetChild("rader");
            m_btn_close = (GButton)GetChild("btn_close");
        }
    }
}