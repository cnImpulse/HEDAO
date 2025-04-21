/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIMenuBattleEnd : GComponent
    {
        public GButton m_btn_sure;
        public GTextField m_txt_result;
        public const string URL = "ui://rt51n0kja4vx68";

        public static FGUIMenuBattleEnd CreateInstance()
        {
            return (FGUIMenuBattleEnd)UIPackage.CreateObject("Common", "MenuBattleEnd");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_sure = (GButton)GetChild("btn_sure");
            m_txt_result = (GTextField)GetChild("txt_result");
        }
    }
}