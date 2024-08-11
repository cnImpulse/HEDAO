using System.Collections;
using System.Collections.Generic;
using HEDAO;
using UnityEngine;

namespace HEDAO
{
    public class WorldMap : GridMap
    {
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_Data = userData as BattleMapData;

            GridUnitData data = new GridUnitData(new Vector2Int(0, 0), CampType.None);
            GameEntry.Entity.ShowGridUnit(data);
        }
    }
}