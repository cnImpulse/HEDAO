/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIRolePanel : GComponent
    {
        public GLoader m_img_bg;
        public GLoader m_img_role;
        public GTextField m_txt_name;
        public GTextField m_txt_hp;
        public GTextField m_txt_qi;
        public const string URL = "ui://rt51n0kjzjyek";

        public static FGUIRolePanel CreateInstance()
        {
            return (FGUIRolePanel)UIPackage.CreateObject("CommonUI", "RolePanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_img_bg = (GLoader)GetChild("img_bg");
            m_img_role = (GLoader)GetChild("img_role");
            m_txt_name = (GTextField)GetChild("txt_name");
            m_txt_hp = (GTextField)GetChild("txt_hp");
            m_txt_qi = (GTextField)GetChild("txt_qi");
        }
    }
}