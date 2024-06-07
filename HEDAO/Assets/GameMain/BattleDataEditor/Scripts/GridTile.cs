using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace HEDAO
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Map Tile", menuName = "GridMap/GridTile")]
    public class GridTile : Tile
    {
        public GridType GridType = GridType.Plain;
    }
}