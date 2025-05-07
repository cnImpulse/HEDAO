/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUICompSkill : GComponent
    {
        public GButton m_btn_role;
        public GList m_list_skill;
        public const string URL = "ui://rt51n0kj76wd6l";

        public static FGUICompSkill CreateInstance()
        {
            return (FGUICompSkill)UIPackage.CreateObject("Common", "CompSkill");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_role = (GButton)GetChild("btn_role");
            m_list_skill = (GList)GetChild("list_skill");
        }
    }
}