using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HEDAO
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Map Tile", menuName = "GridMap/Tile")]
    public class Grid : RuleTile
    {
        public GridType GridType = GridType.Plain;
    }
}