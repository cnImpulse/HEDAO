/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUICompSkillResult : GComponent
    {
        public GTextField m_txt_result;
        public GButton m_btn_sure;
        public const string URL = "ui://rt51n0kjpftu6q";

        public static FGUICompSkillResult CreateInstance()
        {
            return (FGUICompSkillResult)UIPackage.CreateObject("Common", "CompSkillResult");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_txt_result = (GTextField)GetChild("txt_result");
            m_btn_sure = (GButton)GetChild("btn_sure");
        }
    }
}