/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIVerticalList : GComponent
    {
        public Controller m_ctrl_select;
        public GList m_list;
        public const string URL = "ui://rt51n0kjaow85e";

        public static FGUIVerticalList CreateInstance()
        {
            return (FGUIVerticalList)UIPackage.CreateObject("Common", "VerticalList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_ctrl_select = GetController("ctrl_select");
            m_list = (GList)GetChild("list");
        }
    }
}