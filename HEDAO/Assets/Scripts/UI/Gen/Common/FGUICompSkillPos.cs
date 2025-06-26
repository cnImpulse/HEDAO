/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUICompSkillPos : GComponent
    {
        public GList m_list_self;
        public GList m_list_target;
        public const string URL = "ui://rt51n0kjpftu6o";

        public static FGUICompSkillPos CreateInstance()
        {
            return (FGUICompSkillPos)UIPackage.CreateObject("Common", "CompSkillPos");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_self = (GList)GetChild("list_self");
            m_list_target = (GList)GetChild("list_target");
        }
    }
}