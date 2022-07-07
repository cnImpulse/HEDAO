using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HEDAO
{
    [Serializable]
    public class LevelData
    {
        public int LevelId = 0;
        public int MapId = 0;
        [Range(2, 36)]
        public int MapWidth = 18;
        [Range(2, 36)]
        public int MapHeight = 10;

        public Dictionary<int, int> EnemyDic = new Dictionary<int, int>();
        public List<int> PlayerBrithList = new List<int>();
    }
}