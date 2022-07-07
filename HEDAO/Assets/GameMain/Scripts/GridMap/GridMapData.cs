using System;
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HEDAO
{
    public enum GridType
    {
        Plain,
        Obstacle,
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class GridData
    {
        [JsonProperty]
        private int m_GridX;
        [JsonProperty]
        private int m_GridY;
        [JsonProperty]
        private GridType m_GridType;

        public Vector2Int GridPos => new Vector2Int(m_GridX, m_GridY);
        public GridType GridType => m_GridType;

        [JsonConstructor]
        public GridData(Vector2Int gridPos, GridType gridType)
        {
            m_GridX = gridPos.x;
            m_GridY = gridPos.y;
            m_GridType = gridType;
        }
    }

    public class GridMapData : EntityData
    {
        [JsonProperty]
        private Dictionary<int, GridData> m_GridDataDic = null;

        public Dictionary<int, GridData> GridDataDic => m_GridDataDic;

        public GridMapData()
        {
            Name = "GridMap";
            m_GridDataDic = new Dictionary<int, GridData>();
        }

        public bool ExitData(Vector2Int gridPos)
        {
            return m_GridDataDic.ContainsKey(GridPosToIndex(gridPos));
        }

        public void SetGridData(GridData gridData)
        {
            m_GridDataDic[GridPosToIndex(gridData.GridPos)] = gridData;
        }

        public static int GridPosToIndex(Vector2Int gridPos)
        {
            return gridPos.x + gridPos.y * 10000;
        }

        public GridData GetGridData(int gridIndex)
        {
            if (m_GridDataDic.TryGetValue(gridIndex, out var gridData))
            {
                return gridData;
            }

            return null;
        }
    }
}