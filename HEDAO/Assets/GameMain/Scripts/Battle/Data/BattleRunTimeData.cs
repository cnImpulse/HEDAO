using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using UnityEngine;

namespace HEDAO
{
    public class BattleRunTimeData
    {
        public LevelData LevelData { get; private set; }
        public CampType ActiveCamp { get; set; } = CampType.Player;
        public BattleMap BattleMap { get; set; }
        public IFsm<BattleUnit> BattleUnitFsm { get; set; }

        public BattleRunTimeData(LevelData data)
        {
            LevelData = data;
        }
    }
}
