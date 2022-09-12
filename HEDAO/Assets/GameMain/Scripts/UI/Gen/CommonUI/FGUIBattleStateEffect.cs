/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIBattleStateEffect : GLabel
    {
        public Transition m_anim;
        public const string URL = "ui://rt51n0kjvg3s54";

        public static FGUIBattleStateEffect CreateInstance()
        {
            return (FGUIBattleStateEffect)UIPackage.CreateObject("CommonUI", "BattleStateEffect");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_anim = GetTransition("anim");
        }
    }
}