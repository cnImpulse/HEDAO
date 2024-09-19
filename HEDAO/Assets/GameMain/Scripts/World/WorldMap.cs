using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HEDAO;
using LDtkUnity;
using UnityEngine;

namespace HEDAO
{
    public class WorldMap : EntityData
    {
        protected Dictionary<int, WorldGridUnit> m_GridUnitDic = new Dictionary<int, WorldGridUnit>();

        public void RegisterGridUnit(Vector2Int gridPos, LDtkComponentEntity entity)
        {
            var data = new WorldGridUnit(this, gridPos, entity);
            m_GridUnitDic.Add(data.Id, data);
            
            GameEntry.Entity.ShowEntity<WorldGridUnitView>(data, 10001);
        }
    }
}