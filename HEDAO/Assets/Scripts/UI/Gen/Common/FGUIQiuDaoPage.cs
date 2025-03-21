/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIQiuDaoPage : GComponent
    {
        public FGUIVerticalList m_list_role;
        public GRichTextField m_text_role;
        public FGUIRadarGraph m_rader;
        public GButton m_btn_get;
        public const string URL = "ui://rt51n0kjnenx5f";

        public static FGUIQiuDaoPage CreateInstance()
        {
            return (FGUIQiuDaoPage)UIPackage.CreateObject("Common", "QiuDaoPage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_role = (FGUIVerticalList)GetChild("list_role");
            m_text_role = (GRichTextField)GetChild("text_role");
            m_rader = (FGUIRadarGraph)GetChild("rader");
            m_btn_get = (GButton)GetChild("btn_get");
        }
    }
}