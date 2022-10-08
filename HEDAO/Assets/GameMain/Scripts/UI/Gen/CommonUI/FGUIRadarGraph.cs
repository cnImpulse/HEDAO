/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace FGUI.CommonUI
{
    public partial class FGUIRadarGraph : GComponent
    {
        public GGraph m_graph_wuxing;
        public const string URL = "ui://rt51n0kjsoef5a";

        public static FGUIRadarGraph CreateInstance()
        {
            return (FGUIRadarGraph)UIPackage.CreateObject("CommonUI", "RadarGraph");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_graph_wuxing = (GGraph)GetChild("graph_wuxing");
        }
    }
}