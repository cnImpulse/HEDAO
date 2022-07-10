/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUILoadGameItem : GComponent
    {
        public GButton m_btn_load;
        public GButton m_btn_clear;
        public const string URL = "ui://rt51n0kjja3td";

        public static FGUILoadGameItem CreateInstance()
        {
            return (FGUILoadGameItem)UIPackage.CreateObject("CommonUI", "LoadGameItem");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_load = (GButton)GetChild("btn_load");
            m_btn_clear = (GButton)GetChild("btn_clear");
        }
    }
}