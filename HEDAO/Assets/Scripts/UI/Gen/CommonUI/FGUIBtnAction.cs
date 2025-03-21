/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIBtnAction : GButton
    {
        public GTextField m_txt_desc;
        public const string URL = "ui://rt51n0kjokxa5t";

        public static FGUIBtnAction CreateInstance()
        {
            return (FGUIBtnAction)UIPackage.CreateObject("CommonUI", "BtnAction");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_txt_desc = (GTextField)GetChild("txt_desc");
        }
    }
}