/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIFloatBubble : GComponent
    {
        public GTextField m_title;
        public Transition m_fade_close;
        public const string URL = "ui://rt51n0kjm3nj67";

        public static FGUIFloatBubble CreateInstance()
        {
            return (FGUIFloatBubble)UIPackage.CreateObject("Common", "FloatBubble");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_title = (GTextField)GetChild("title");
            m_fade_close = GetTransition("fade_close");
        }
    }
}