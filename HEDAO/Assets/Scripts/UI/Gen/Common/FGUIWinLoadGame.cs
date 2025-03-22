/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIWinLoadGame : GComponent
    {
        public GList m_list;
        public GButton m_btn_close;
        public const string URL = "ui://rt51n0kjja3tc";

        public static FGUIWinLoadGame CreateInstance()
        {
            return (FGUIWinLoadGame)UIPackage.CreateObject("Common", "WinLoadGame");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list = (GList)GetChild("list");
            m_btn_close = (GButton)GetChild("btn_close");
        }
    }
}