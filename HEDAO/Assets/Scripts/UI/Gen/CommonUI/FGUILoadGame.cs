/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUILoadGame : GComponent
    {
        public GList m_list;
        public GButton m_btn_close;
        public const string URL = "ui://rt51n0kjja3tc";

        public static FGUILoadGame CreateInstance()
        {
            return (FGUILoadGame)UIPackage.CreateObject("CommonUI", "LoadGame");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list = (GList)GetChild("list");
            m_btn_close = (GButton)GetChild("btn_close");
        }
    }
}