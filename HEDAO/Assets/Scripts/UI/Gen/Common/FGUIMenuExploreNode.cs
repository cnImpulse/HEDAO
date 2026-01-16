/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIMenuExploreNode : GComponent
    {
        public GTextField m_title;
        public GTextField m_txt_desc;
        public GList m_list_option;
        public const string URL = "ui://rt51n0kjip036v";

        public static FGUIMenuExploreNode CreateInstance()
        {
            return (FGUIMenuExploreNode)UIPackage.CreateObject("Common", "MenuExploreNode");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_title = (GTextField)GetChild("title");
            m_txt_desc = (GTextField)GetChild("txt_desc");
            m_list_option = (GList)GetChild("list_option");
        }
    }
}