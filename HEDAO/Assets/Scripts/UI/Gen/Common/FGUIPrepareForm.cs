/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIPrepareForm : GComponent
    {
        public FGUIVerticalList m_list_team;
        public GButton m_btn_go;
        public GButton m_btn_return;
        public const string URL = "ui://rt51n0kjmv3558";

        public static FGUIPrepareForm CreateInstance()
        {
            return (FGUIPrepareForm)UIPackage.CreateObject("Common", "PrepareForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_team = (FGUIVerticalList)GetChild("list_team");
            m_btn_go = (GButton)GetChild("btn_go");
            m_btn_return = (GButton)GetChild("btn_return");
        }
    }
}