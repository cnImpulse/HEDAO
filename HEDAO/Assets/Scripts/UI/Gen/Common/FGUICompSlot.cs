/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUICompSlot : GComponent
    {
        public GButton m_btn_slot;
        public GTextField m_txt_type;
        public const string URL = "ui://rt51n0kja4vx6h";

        public static FGUICompSlot CreateInstance()
        {
            return (FGUICompSlot)UIPackage.CreateObject("Common", "CompSlot");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_slot = (GButton)GetChild("btn_slot");
            m_txt_type = (GTextField)GetChild("txt_type");
        }
    }
}