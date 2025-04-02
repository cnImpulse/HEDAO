/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIFloatBattleUnit : GComponent
    {
        public GTextField m_txt_name;
        public GProgressBar m_hp_bar;
        public GProgressBar m_qi_bar;
        public const string URL = "ui://rt51n0kjqwwl51";

        public static FGUIFloatBattleUnit CreateInstance()
        {
            return (FGUIFloatBattleUnit)UIPackage.CreateObject("Common", "FloatBattleUnit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_txt_name = (GTextField)GetChild("txt_name");
            m_hp_bar = (GProgressBar)GetChild("hp_bar");
            m_qi_bar = (GProgressBar)GetChild("qi_bar");
        }
    }
}