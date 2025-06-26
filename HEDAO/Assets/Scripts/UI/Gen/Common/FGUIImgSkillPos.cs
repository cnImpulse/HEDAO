/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIImgSkillPos : GComponent
    {
        public GLoader m_img_pos;
        public const string URL = "ui://rt51n0kjpftu6p";

        public static FGUIImgSkillPos CreateInstance()
        {
            return (FGUIImgSkillPos)UIPackage.CreateObject("Common", "ImgSkillPos");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_img_pos = (GLoader)GetChild("img_pos");
        }
    }
}