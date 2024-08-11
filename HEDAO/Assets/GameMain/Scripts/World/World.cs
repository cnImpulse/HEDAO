using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HEDAO
{
    [Serializable]
    public class World
    {
        public int WorldId;
        public int MapId;

        public GridUnitData ZongMeng;
        public List<GridUnitData> Building;

        public World()
        {
            ZongMeng = new GridUnitData(new Vector2Int(0, 0), CampType.Player);

            var data = new GridUnitData(new Vector2Int(3, 3), CampType.None);
            Building = new List<GridUnitData>();
            Building.Add(data);
        }
    }
}
