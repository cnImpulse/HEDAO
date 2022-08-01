/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIActionPanel : GComponent
    {
        public GTextField m_title;
        public GList m_list_action;
        public const string URL = "ui://rt51n0kjuyzr4t";

        public static FGUIActionPanel CreateInstance()
        {
            return (FGUIActionPanel)UIPackage.CreateObject("CommonUI", "ActionPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_title = (GTextField)GetChild("title");
            m_list_action = (GList)GetChild("list_action");
        }
    }
}