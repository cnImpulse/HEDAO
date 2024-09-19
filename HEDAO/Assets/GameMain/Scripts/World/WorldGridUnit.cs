using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cfg;
using HEDAO;
using LDtkUnity;
using UnityEngine;

namespace HEDAO
{
    public class WorldGridUnit : EntityData
    {
        public WorldMap Parent { get; private set; }
        public Vector2Int GridPos { get; private set; }
        public int CfgId { get; private set; }
        public WorldUnitCfg Cfg => GameEntry.Cfg.Tables.TbWorldUnitCfg.Get(CfgId);

        public LDtkComponentEntity Template { get; private set; }

        public WorldGridUnit(WorldMap parent, Vector2Int gridPos, LDtkComponentEntity template)
        {
            Parent = parent;
            GridPos = gridPos;
            Template = template;
            CfgId = template.FieldInstances.GetInt("cfgId");
            Name = Cfg.Name;
        }
    }
}