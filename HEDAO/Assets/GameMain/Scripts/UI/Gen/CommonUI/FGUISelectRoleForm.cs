/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUISelectRoleForm : GComponent
    {
        public GButton m_btn_sure;
        public GList m_list;
        public const string URL = "ui://rt51n0kjzjyej";

        public static FGUISelectRoleForm CreateInstance()
        {
            return (FGUISelectRoleForm)UIPackage.CreateObject("CommonUI", "SelectRoleForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_sure = (GButton)GetChild("btn_sure");
            m_list = (GList)GetChild("list");
        }
    }
}