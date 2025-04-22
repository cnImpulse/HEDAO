/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIMenuStore : GComponent
    {
        public GList m_list_type;
        public GList m_list_item;
        public const string URL = "ui://rt51n0kja4vx6a";

        public static FGUIMenuStore CreateInstance()
        {
            return (FGUIMenuStore)UIPackage.CreateObject("Common", "MenuStore");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_type = (GList)GetChild("list_type");
            m_list_item = (GList)GetChild("list_item");
        }
    }
}