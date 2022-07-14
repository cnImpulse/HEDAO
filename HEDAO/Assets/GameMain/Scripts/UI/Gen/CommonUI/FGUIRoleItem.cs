/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIRoleItem : GButton
    {
        public FGUIRolePanel m_panel_role;
        public const string URL = "ui://rt51n0kjga5tm";

        public static FGUIRoleItem CreateInstance()
        {
            return (FGUIRoleItem)UIPackage.CreateObject("CommonUI", "RoleItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_panel_role = (FGUIRolePanel)GetChild("panel_role");
        }
    }
}