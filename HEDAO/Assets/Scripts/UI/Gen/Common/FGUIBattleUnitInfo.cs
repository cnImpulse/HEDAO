/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIBattleUnitInfo : GComponent
    {
        public GTextField m_name_txt;
        public FGUIHPBar m_hp_bar;
        public GProgressBar m_qi_bar;
        public const string URL = "ui://rt51n0kjqwwl51";

        public static FGUIBattleUnitInfo CreateInstance()
        {
            return (FGUIBattleUnitInfo)UIPackage.CreateObject("Common", "BattleUnitInfo");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_name_txt = (GTextField)GetChild("name_txt");
            m_hp_bar = (FGUIHPBar)GetChild("hp_bar");
            m_qi_bar = (GProgressBar)GetChild("qi_bar");
        }
    }
}