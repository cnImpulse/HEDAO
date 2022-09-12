/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUICommonTips : GLabel
    {
        public Transition m_fade_close;
        public const string URL = "ui://rt51n0kjrzkn50";

        public static FGUICommonTips CreateInstance()
        {
            return (FGUICommonTips)UIPackage.CreateObject("CommonUI", "CommonTips");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_fade_close = GetTransition("fade_close");
        }
    }
}