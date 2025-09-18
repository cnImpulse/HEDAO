/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUICompSkill : GComponent
    {
        public Controller m_select_ctrl;
        public GButton m_btn_role;
        public GList m_list_skill;
        public GTextField m_txt_skill;
        public FGUICompSkillPos m_comp_skill_pos;
        public GButton m_btn_jump;
        public const string URL = "ui://rt51n0kj76wd6l";

        public static FGUICompSkill CreateInstance()
        {
            return (FGUICompSkill)UIPackage.CreateObject("Common", "CompSkill");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_select_ctrl = GetController("select_ctrl");
            m_btn_role = (GButton)GetChild("btn_role");
            m_list_skill = (GList)GetChild("list_skill");
            m_txt_skill = (GTextField)GetChild("txt_skill");
            m_comp_skill_pos = (FGUICompSkillPos)GetChild("comp_skill_pos");
            m_btn_jump = (GButton)GetChild("btn_jump");
        }
    }
}