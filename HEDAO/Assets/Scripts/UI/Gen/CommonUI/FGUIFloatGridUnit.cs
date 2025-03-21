/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIFloatGridUnit : GComponent
    {
        public GTextField m_title;
        public const string URL = "ui://rt51n0kjgq3i5r";

        public static FGUIFloatGridUnit CreateInstance()
        {
            return (FGUIFloatGridUnit)UIPackage.CreateObject("CommonUI", "FloatGridUnit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_title = (GTextField)GetChild("title");
        }
    }
}