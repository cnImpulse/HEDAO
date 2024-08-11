/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUITaskList : GComponent
    {
        public GList m_list;
        public GButton m_btn_go;
        public const string URL = "ui://rt51n0kjgv665q";

        public static FGUITaskList CreateInstance()
        {
            return (FGUITaskList)UIPackage.CreateObject("CommonUI", "TaskList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list = (GList)GetChild("list");
            m_btn_go = (GButton)GetChild("btn_go");
        }
    }
}