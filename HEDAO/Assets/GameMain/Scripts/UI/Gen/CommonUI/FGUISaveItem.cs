/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUISaveItem : GComponent
    {
        public GButton m_btn_clear;
        public GButton m_btn_load;
        public const string URL = "ui://rt51n0kjja3td";

        public static FGUISaveItem CreateInstance()
        {
            return (FGUISaveItem)UIPackage.CreateObject("CommonUI", "SaveItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_clear = (GButton)GetChild("btn_clear");
            m_btn_load = (GButton)GetChild("btn_load");
        }
    }
}