/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIHPBar : GProgressBar
    {
        public GTextField m_text;
        public const string URL = "ui://rt51n0kjdl574x";

        public static FGUIHPBar CreateInstance()
        {
            return (FGUIHPBar)UIPackage.CreateObject("CommonUI", "HPBar");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_text = (GTextField)GetChild("text");
        }
    }
}