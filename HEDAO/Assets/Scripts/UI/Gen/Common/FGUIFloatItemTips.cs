/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIFloatItemTips : GComponent
    {
        public GTextField m_title;
        public GList m_list_select;
        public const string URL = "ui://rt51n0kjlu5o6j";

        public static FGUIFloatItemTips CreateInstance()
        {
            return (FGUIFloatItemTips)UIPackage.CreateObject("Common", "FloatItemTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_title = (GTextField)GetChild("title");
            m_list_select = (GList)GetChild("list_select");
        }
    }
}