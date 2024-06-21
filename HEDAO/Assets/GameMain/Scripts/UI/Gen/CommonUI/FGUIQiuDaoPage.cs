/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIQiuDaoPage : GComponent
    {
        public FGUIVerticalList m_list_role;
        public const string URL = "ui://rt51n0kjnenx5f";

        public static FGUIQiuDaoPage CreateInstance()
        {
            return (FGUIQiuDaoPage)UIPackage.CreateObject("CommonUI", "QiuDaoPage");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_role = (FGUIVerticalList)GetChild("list_role");
        }
    }
}