/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIMenuActionSelect : GComponent
    {
        public GList m_list_action;
        public const string URL = "ui://rt51n0kjokxa5s";

        public static FGUIMenuActionSelect CreateInstance()
        {
            return (FGUIMenuActionSelect)UIPackage.CreateObject("CommonUI", "MenuActionSelect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_action = (GList)GetChild("list_action");
        }
    }
}