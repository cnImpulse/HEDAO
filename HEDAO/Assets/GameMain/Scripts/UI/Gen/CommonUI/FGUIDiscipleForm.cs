/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIDiscipleForm : GComponent
    {
        public GList m_list_disciple;
        public GLoader m_img_disciple;
        public GTextField m_txt_level;
        public GTextField m_txt_hp;
        public GTextField m_txt_qi;
        public GTextField m_txt_atk;
        public GTextField m_txt_def;
        public GTextField m_txt_name;
        public GButton m_btn_close;
        public FGUIRadarGraph m_rader;
        public GList m_list_skill;
        public const string URL = "ui://rt51n0kjmv3557";

        public static FGUIDiscipleForm CreateInstance()
        {
            return (FGUIDiscipleForm)UIPackage.CreateObject("CommonUI", "DiscipleForm");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list_disciple = (GList)GetChild("list_disciple");
            m_img_disciple = (GLoader)GetChild("img_disciple");
            m_txt_level = (GTextField)GetChild("txt_level");
            m_txt_hp = (GTextField)GetChild("txt_hp");
            m_txt_qi = (GTextField)GetChild("txt_qi");
            m_txt_atk = (GTextField)GetChild("txt_atk");
            m_txt_def = (GTextField)GetChild("txt_def");
            m_txt_name = (GTextField)GetChild("txt_name");
            m_btn_close = (GButton)GetChild("btn_close");
            m_rader = (FGUIRadarGraph)GetChild("rader");
            m_list_skill = (GList)GetChild("list_skill");
        }
    }
}