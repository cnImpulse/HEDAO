/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIHudBattle : GComponent
    {
        public GTextField m_txt_battle_state;
        public GList m_list_action;
        public FGUICompSkill m_comp_skill;
        public FGUICompSkillResult m_comp_skill_result;
        public const string URL = "ui://rt51n0kjut3j4p";

        public static FGUIHudBattle CreateInstance()
        {
            return (FGUIHudBattle)UIPackage.CreateObject("Common", "HudBattle");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_txt_battle_state = (GTextField)GetChild("txt_battle_state");
            m_list_action = (GList)GetChild("list_action");
            m_comp_skill = (FGUICompSkill)GetChild("comp_skill");
            m_comp_skill_result = (FGUICompSkillResult)GetChild("comp_skill_result");
        }
    }
}