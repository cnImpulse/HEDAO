/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIMenuExplore : GComponent
    {
        public GList m_list_role;
        public GList m_list_node;
        public const string URL = "ui://rt51n0kjseah62";

        public static FGUIMenuExplore CreateInstance()
        {
            return (FGUIMenuExplore)UIPackage.CreateObject("Common", "MenuExplore");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_role = (GList)GetChild("list_role");
            m_list_node = (GList)GetChild("list_node");
        }
    }
}