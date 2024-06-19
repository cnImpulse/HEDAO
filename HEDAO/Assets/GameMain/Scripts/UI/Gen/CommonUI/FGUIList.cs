/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIList : GComponent
    {
        public GList m_list;
        public const string URL = "ui://rt51n0kjaow85c";

        public static FGUIList CreateInstance()
        {
            return (FGUIList)UIPackage.CreateObject("CommonUI", "List");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list = (GList)GetChild("list");
        }
    }
}