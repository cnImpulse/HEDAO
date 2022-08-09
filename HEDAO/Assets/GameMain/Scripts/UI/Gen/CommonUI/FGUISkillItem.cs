/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUISkillItem : GButton
    {
        public GTextField m_text_name;
        public GTextField m_text_cost;
        public const string URL = "ui://rt51n0kjl0qc4w";

        public static FGUISkillItem CreateInstance()
        {
            return (FGUISkillItem)UIPackage.CreateObject("CommonUI", "SkillItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_text_name = (GTextField)GetChild("text_name");
            m_text_cost = (GTextField)GetChild("text_cost");
        }
    }
}