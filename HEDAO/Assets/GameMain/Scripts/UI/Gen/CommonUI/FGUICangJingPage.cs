/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUICangJingPage : GComponent
    {
        public FGUIVerticalList m_list_role;
        public GList m_list;
        public const string URL = "ui://rt51n0kjlcvv5g";

        public static FGUICangJingPage CreateInstance()
        {
            return (FGUICangJingPage)UIPackage.CreateObject("CommonUI", "CangJingPage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_role = (FGUIVerticalList)GetChild("list_role");
            m_list = (GList)GetChild("list");
        }
    }
}