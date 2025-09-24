/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUIFloatBattleUnit : GComponent
    {
        public GProgressBar m_shield_bar;
        public GProgressBar m_hp_bar;
        public GProgressBar m_qi_bar;
        public GTextField m_txt_name;
        public GList m_list_buff;
        public const string URL = "ui://rt51n0kjqwwl51";

        public static FGUIFloatBattleUnit CreateInstance()
        {
            return (FGUIFloatBattleUnit)UIPackage.CreateObject("Common", "FloatBattleUnit");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_shield_bar = (GProgressBar)GetChild("shield_bar");
            m_hp_bar = (GProgressBar)GetChild("hp_bar");
            m_qi_bar = (GProgressBar)GetChild("qi_bar");
            m_txt_name = (GTextField)GetChild("txt_name");
            m_list_buff = (GList)GetChild("list_buff");
        }
    }
}