/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIBattleForm : GComponent
    {
        public GButton m_btn_start;
        public GLabel m_label_camp;
        public const string URL = "ui://rt51n0kjut3j4p";

        public static FGUIBattleForm CreateInstance()
        {
            return (FGUIBattleForm)UIPackage.CreateObject("CommonUI", "BattleForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_start = (GButton)GetChild("btn_start");
            m_label_camp = (GLabel)GetChild("label_camp");
        }
    }
}