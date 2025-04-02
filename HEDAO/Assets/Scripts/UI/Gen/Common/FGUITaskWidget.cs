/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.Common
{
    public partial class FGUITaskWidget : GComponent
    {
        public GTextField m_title;
        public GTextField m_txt_taskinfo;
        public GButton m_btn_go;
        public const string URL = "ui://rt51n0kjgv665q";

        public static FGUITaskWidget CreateInstance()
        {
            return (FGUITaskWidget)UIPackage.CreateObject("Common", "TaskWidget");
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