/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUILoadGame : GComponent
    {
        public GButton m_closeButton;
        public GList m_list_load;
        public const string URL = "ui://rt51n0kjja3tc";

        public static FGUILoadGame CreateInstance()
        {
            return (FGUILoadGame)UIPackage.CreateObject("CommonUI", "LoadGame");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_closeButton = (GButton)GetChild("closeButton");
            m_list_load = (GList)GetChild("list_load");
        }
    }
}