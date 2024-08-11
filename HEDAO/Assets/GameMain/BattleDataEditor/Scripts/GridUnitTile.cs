using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HEDAO
{
    [Serializable]
    [CreateAssetMenu(fileName = "New BattleUnitTile", menuName = "BattleMap/GridUnitTile")]
    public class GridUnitTile : Tile
    {
        public int Id = 0;
    }
}