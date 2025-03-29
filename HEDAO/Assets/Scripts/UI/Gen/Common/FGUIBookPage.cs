/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIBookPage : GComponent
    {
        public Controller m_ctrl_select;
        public Controller m_ctrl_book_type;
        public FGUIVerticalList m_list_role;
        public GList m_list_book;
        public GList m_list_book_type;
        public GButton m_btn_learn;
        public GLabel m_txt_book;
        public FGUIRadarWidget m_rader;
        public const string URL = "ui://rt51n0kjlcvv5g";

        public static FGUIBookPage CreateInstance()
        {
            return (FGUIBookPage)UIPackage.CreateObject("Common", "BookPage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_ctrl_select = GetController("ctrl_select");
            m_ctrl_book_type = GetController("ctrl_book_type");
            m_list_role = (FGUIVerticalList)GetChild("list_role");
            m_list_book = (GList)GetChild("list_book");
            m_list_book_type = (GList)GetChild("list_book_type");
            m_btn_learn = (GButton)GetChild("btn_learn");
            m_txt_book = (GLabel)GetChild("txt_book");
            m_rader = (FGUIRadarWidget)GetChild("rader");
        }
    }
}