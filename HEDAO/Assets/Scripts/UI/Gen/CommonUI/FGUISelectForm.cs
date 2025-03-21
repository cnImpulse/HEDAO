/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUISelectForm : GComponent
    {
        public GButton m_btn_check;
        public GList m_list;
        public GButton m_btn_return;
        public GButton m_btn_sure;
        public const string URL = "ui://rt51n0kjzjyej";

        public static FGUISelectForm CreateInstance()
        {
            return (FGUISelectForm)UIPackage.CreateObject("CommonUI", "SelectForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_check = (GButton)GetChild("btn_check");
            m_list = (GList)GetChild("list");
            m_btn_return = (GButton)GetChild("btn_return");
            m_btn_sure = (GButton)GetChild("btn_sure");
        }
    }
}