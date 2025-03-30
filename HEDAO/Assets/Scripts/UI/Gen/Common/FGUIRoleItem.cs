/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIRoleItem : GComponent
    {
        public GButton m_btn_role;
        public GProgressBar m_bar_hp;
        public GProgressBar m_bar_qi;
        public const string URL = "ui://rt51n0kjseah63";

        public static FGUIRoleItem CreateInstance()
        {
            return (FGUIRoleItem)UIPackage.CreateObject("Common", "RoleItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_role = (GButton)GetChild("btn_role");
            m_bar_hp = (GProgressBar)GetChild("bar_hp");
            m_bar_qi = (GProgressBar)GetChild("bar_qi");
        }
    }
}