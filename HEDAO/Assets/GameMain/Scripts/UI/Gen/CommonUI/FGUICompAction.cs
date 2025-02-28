/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUICompAction : GComponent
    {
        public GTextField m_title;
        public GTextField m_txt_desc;
        public const string URL = "ui://rt51n0kjokxa5t";

        public static FGUICompAction CreateInstance()
        {
            return (FGUICompAction)UIPackage.CreateObject("CommonUI", "CompAction");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_title = (GTextField)GetChild("title");
            m_txt_desc = (GTextField)GetChild("txt_desc");
        }
    }
}