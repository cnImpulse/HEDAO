/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIMainForm : GComponent
    {
        public GButton m_btn_go;
        public GButton m_btn_disciple;
        public FGUIList m_list_building;
        public FGUIQiuDaoPage m_page_qiudao;
        public FGUICangJingPage m_page_cangjing;
        public const string URL = "ui://rt51n0kjmv3555";

        public static FGUIMainForm CreateInstance()
        {
            return (FGUIMainForm)UIPackage.CreateObject("CommonUI", "MainForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_btn_go = (GButton)GetChild("btn_go");
            m_btn_disciple = (GButton)GetChild("btn_disciple");
            m_list_building = (FGUIList)GetChild("list_building");
            m_page_qiudao = (FGUIQiuDaoPage)GetChild("page_qiudao");
            m_page_cangjing = (FGUICangJingPage)GetChild("page_cangjing");
        }
    }
}