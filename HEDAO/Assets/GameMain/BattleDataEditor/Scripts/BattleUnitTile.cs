using System;
using UnityEngine;

namespace HEDAO
{
    [Serializable]
    [CreateAssetMenu(fileName = "New BattleUnitTile", menuName = "BattleMap/BattleUnitTile")]
    public class BattleUnitTile : RuleTile
    {
        public int Id = 0;
    }
}