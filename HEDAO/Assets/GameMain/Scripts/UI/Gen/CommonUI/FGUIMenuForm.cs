/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIMenuForm : GComponent
    {
        public GButton m_btn_new;
        public GButton m_btn_lod;
        public GButton m_btn_exit;
        public const string URL = "ui://rt51n0kjdsjm0";

        public static FGUIMenuForm CreateInstance()
        {
            return (FGUIMenuForm)UIPackage.CreateObject("CommonUI", "MenuForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_new = (GButton)GetChild("btn_new");
            m_btn_lod = (GButton)GetChild("btn_lod");
            m_btn_exit = (GButton)GetChild("btn_exit");
        }
    }
}