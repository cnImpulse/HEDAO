using System.Collections.Generic;
using UnityEngine;

public class GridEffectData : EffectData
{
    public List<Vector2Int> GridList;
    public Color Color;
    public GridEffectData(int prefabId, Vector3 position, float lifetime) : base(prefabId, position, lifetime)
    {

    }
}
