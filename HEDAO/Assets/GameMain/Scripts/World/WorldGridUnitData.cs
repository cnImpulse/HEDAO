using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HEDAO;
using LDtkUnity;
using UnityEngine;

namespace HEDAO
{
    public class WorldGridUnitData : EntityData
    {
        public WorldMapData Parent { get; private set; }
        public Vector2Int GridPos { get; private set; }

        public LDtkComponentEntity Template { get; private set; }

        public WorldGridUnitData(WorldMapData parent, Vector2Int gridPos, LDtkComponentEntity template)
        {
            Parent = parent;
            GridPos = gridPos;
            Template = template;
            Name = "WorldGridUnit";
        }
    }
}