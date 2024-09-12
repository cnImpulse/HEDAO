using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HEDAO;
using LDtkUnity;
using UnityEngine;

namespace HEDAO
{
    public class WorldMapData : EntityData
    {
        protected Dictionary<int, WorldGridUnitData> m_GridUnitDic = new Dictionary<int, WorldGridUnitData>();

        public void RegisterGridUnit(Vector2Int gridPos, LDtkComponentEntity entity)
        {
            var data = new WorldGridUnitData(this, gridPos, entity);
            m_GridUnitDic.Add(data.Id, data);
            
            GameEntry.Entity.ShowEntity<WorldGridUnit>(data, 10001);
        }
    }
}