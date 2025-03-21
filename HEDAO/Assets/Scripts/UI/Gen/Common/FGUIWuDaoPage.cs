/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIWuDaoPage : GComponent
    {
        public FGUIVerticalList m_list_role;
        public const string URL = "ui://rt51n0kjoq905j";

        public static FGUIWuDaoPage CreateInstance()
        {
            return (FGUIWuDaoPage)UIPackage.CreateObject("Common", "WuDaoPage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_role = (FGUIVerticalList)GetChild("list_role");
        }
    }
}