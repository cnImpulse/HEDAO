using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    public class GridEffectData : EffectData
    {
        public Color Color { get; private set; }
        public string GridEffectName { get; private set; }
        public List<Vector2Int> GridPosList { get; private set; }

        public GridEffectData(List<Vector2Int> gridPosList, string name, Color color = default, Vector3 position = default, float lifetime = -1)
            : base("GridEffect", position, lifetime)
        {
            Color = color;
            GridEffectName = name;
            GridPosList = gridPosList == null ? new List<Vector2Int>() : gridPosList;
            Name = Name + "-" + GridEffectName;
        }
    }
}