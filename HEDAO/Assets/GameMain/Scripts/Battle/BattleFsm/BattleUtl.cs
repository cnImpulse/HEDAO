using GameFramework;
using UnityEngine;
using System.Collections.Generic;

namespace HEDAO
{
    public static class BattleUtl
    {
        public static CampType GetHostileCamp(CampType campType)
        {
            if (campType == CampType.Enemy)
            {
                return CampType.Player;
            }
            else if (campType == CampType.Player)
            {
                return CampType.Enemy;
            }

            return CampType.None;
        }

        public static string GetHexCampColor(CampType camp)
        {
            if (camp == CampType.Player)
            {
                return "#70FFF0";
            }
            else if (camp == CampType.Enemy)
            {
                return "#FF7070";
            }

            return "#FFFFFF";
        }

        public static Color GetCampColor(CampType camp)
        {
            ColorUtility.TryParseHtmlString(GetHexCampColor(camp), out var color);
            return color;
        }

        public static string GetText(CampType camp, string text)
        {
            string color = GetHexCampColor(camp);
            return string.Format("[color={0}]{1}[/color]", color, text);
        }

        public static string GetCampText(CampType camp)
        {
            if (camp == CampType.Player)
            {
                return "己方";
            }
            return "敌方";
        }
    }
}