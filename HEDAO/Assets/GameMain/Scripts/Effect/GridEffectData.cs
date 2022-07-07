using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class GridEffectData : EffectData
    {
        public string GridEffectName { get; private set; }
        public List<Vector2Int> GridPosList { get; private set; }

        public GridEffectData(List<Vector2Int> gridPosList, string name,Vector3 position, float lifetime) : base("GridEffect", position, lifetime)
        {
            GridEffectName = name;
            GridPosList = gridPosList == null ? new List<Vector2Int>() : gridPosList;
            Name = Name + "-" + GridEffectName;
        }
    }
}