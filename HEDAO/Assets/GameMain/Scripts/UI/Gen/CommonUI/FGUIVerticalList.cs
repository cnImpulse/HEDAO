/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIVerticalList : GComponent
    {
        public GList m_list;
        public const string URL = "ui://rt51n0kjaow85e";

        public static FGUIVerticalList CreateInstance()
        {
            return (FGUIVerticalList)UIPackage.CreateObject("CommonUI", "VerticalList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list = (GList)GetChild("list");
        }
    }
}