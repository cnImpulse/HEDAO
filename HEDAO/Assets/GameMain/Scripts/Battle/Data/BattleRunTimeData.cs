using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class BattleRunTimeData
    {
        public LevelData LevelData { get; private set; }
        public CampType ActiveCamp { get; set; } = CampType.Player;
        public GridMap GridMap { get; set; }

        public BattleRunTimeData(LevelData data)
        {
            LevelData = data;
        }
    }
}
