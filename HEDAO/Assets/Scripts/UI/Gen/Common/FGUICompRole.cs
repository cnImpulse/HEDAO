/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUICompRole : GComponent
    {
        public Controller m_ctrl_select;
        public GList m_list_book;
        public GList m_list_equip;
        public GLabel m_txt_name;
        public GList m_list_role;
        public const string URL = "ui://rt51n0kja4vx6e";

        public static FGUICompRole CreateInstance()
        {
            return (FGUICompRole)UIPackage.CreateObject("Common", "CompRole");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_ctrl_select = GetController("ctrl_select");
            m_list_book = (GList)GetChild("list_book");
            m_list_equip = (GList)GetChild("list_equip");
            m_txt_name = (GLabel)GetChild("txt_name");
            m_list_role = (GList)GetChild("list_role");
        }
    }
}