using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

            GameEntry.Entity.ShowGridUnit(GameEntry.Save.PlayerData.World.ZongMeng);
            GameEntry.Entity.ShowGridUnit(GameEntry.Save.PlayerData.World.Building[0]);
        }
    }
}