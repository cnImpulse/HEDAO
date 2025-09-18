/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUICompSkillPos : GComponent
    {
        public GList m_list_self;
        public GList m_list_target;
        public GImage m_img_line_1;
        public GImage m_img_line_2;
        public GImage m_img_line_3;
        public GGroup m_group_line;
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
            m_img_line_1 = (GImage)GetChild("img_line_1");
            m_img_line_2 = (GImage)GetChild("img_line_2");
            m_img_line_3 = (GImage)GetChild("img_line_3");
            m_group_line = (GGroup)GetChild("group_line");
        }
    }
}