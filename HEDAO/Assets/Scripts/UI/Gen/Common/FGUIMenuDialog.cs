/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIMenuDialog : GComponent
    {
        public GButton m_btn_sure;
        public GTextField m_title;
        public GTextField m_txt_desc;
        public const string URL = "ui://rt51n0kjip036v";

        public static FGUIMenuDialog CreateInstance()
        {
            return (FGUIMenuDialog)UIPackage.CreateObject("Common", "MenuDialog");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_sure = (GButton)GetChild("btn_sure");
            m_title = (GTextField)GetChild("title");
            m_txt_desc = (GTextField)GetChild("txt_desc");
        }
    }
}