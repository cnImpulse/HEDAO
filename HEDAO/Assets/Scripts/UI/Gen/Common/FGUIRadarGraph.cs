/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIRadarGraph : GComponent
    {
        public GGraph m_img_wuxing;
        public GTextField m_text_wuxin_0;
        public GTextField m_text_wuxin_1;
        public GTextField m_text_wuxin_2;
        public GTextField m_text_wuxin_3;
        public GTextField m_text_wuxin_4;
        public const string URL = "ui://rt51n0kjsoef5a";

        public static FGUIRadarGraph CreateInstance()
        {
            return (FGUIRadarGraph)UIPackage.CreateObject("Common", "RadarGraph");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_img_wuxing = (GGraph)GetChild("img_wuxing");
            m_text_wuxin_0 = (GTextField)GetChild("text_wuxin_0");
            m_text_wuxin_1 = (GTextField)GetChild("text_wuxin_1");
            m_text_wuxin_2 = (GTextField)GetChild("text_wuxin_2");
            m_text_wuxin_3 = (GTextField)GetChild("text_wuxin_3");
            m_text_wuxin_4 = (GTextField)GetChild("text_wuxin_4");
        }
    }
}