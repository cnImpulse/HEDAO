/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIMenuExplore : GComponent
    {
        public GList m_list_role;
        public GButton m_btn_return;
        public GTextField m_txt_time;
        public GButton m_btn_prepare;
        public const string URL = "ui://rt51n0kjseah62";

        public static FGUIMenuExplore CreateInstance()
        {
            return (FGUIMenuExplore)UIPackage.CreateObject("Common", "MenuExplore");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_role = (GList)GetChild("list_role");
            m_btn_return = (GButton)GetChild("btn_return");
            m_txt_time = (GTextField)GetChild("txt_time");
            m_btn_prepare = (GButton)GetChild("btn_prepare");
        }
    }
}