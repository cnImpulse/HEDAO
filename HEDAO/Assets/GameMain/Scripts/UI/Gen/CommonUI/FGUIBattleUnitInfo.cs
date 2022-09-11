/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIBattleUnitInfo : GComponent
    {
        public GProgressBar m_hp_bar;
        public GProgressBar m_qi_bar;
        public const string URL = "ui://rt51n0kjqwwl51";

        public static FGUIBattleUnitInfo CreateInstance()
        {
            return (FGUIBattleUnitInfo)UIPackage.CreateObject("CommonUI", "BattleUnitInfo");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_hp_bar = (GProgressBar)GetChild("hp_bar");
            m_qi_bar = (GProgressBar)GetChild("qi_bar");
        }
    }
}