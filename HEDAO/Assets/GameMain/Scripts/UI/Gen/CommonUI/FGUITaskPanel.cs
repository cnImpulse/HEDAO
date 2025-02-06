/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUITaskPanel : GComponent
    {
        public GTextField m_title;
        public GTextField m_txt_taskinfo;
        public GButton m_btn_go;
        public const string URL = "ui://rt51n0kjgv665q";

        public static FGUITaskPanel CreateInstance()
        {
            return (FGUITaskPanel)UIPackage.CreateObject("CommonUI", "TaskPanel");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_title = (GTextField)GetChild("title");
            m_txt_taskinfo = (GTextField)GetChild("txt_taskinfo");
            m_btn_go = (GButton)GetChild("btn_go");
        }
    }
}