/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIFloatTips : GComponent
    {
        public GLabel m_label;
        public GButton m_btn_close;
        public Transition m_fade_close;
        public const string URL = "ui://rt51n0kjrzkn50";

        public static FGUIFloatTips CreateInstance()
        {
            return (FGUIFloatTips)UIPackage.CreateObject("Common", "FloatTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_label = (GLabel)GetChild("label");
            m_btn_close = (GButton)GetChild("btn_close");
            m_fade_close = GetTransition("fade_close");
        }
    }
}