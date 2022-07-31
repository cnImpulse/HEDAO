using System;
using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityGameFramework.Runtime;

namespace HEDAO
{
    public enum GridType
    {
        Plain,
        Obstacle,
    }

    /// <summary>
    /// 邻居网格类型
    /// </summary>
    public enum NeighborType
    {
        None,
        CanAcross,
        CanArrive,
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
        public int GridIndex => GridMapUtl.GridPosToIndex(GridPos);

        [JsonConstructor]
        public GridData(Vector2Int gridPos, GridType gridType)
        {
            m_GridX = gridPos.x;
            m_GridY = gridPos.y;
            m_GridType = gridType;
        }

        /// <summary>
        /// 占据的网格单位
        /// </summary>
        public GridUnit GridUnit { get; private set; }

        public void OnGridUnitEnter(GridUnit gridUnit)
        {
            if (GridUnit != null)
            {
                Log.Error("单元格已经被占据,无法进入!");
                return;
            }

            GridUnit = gridUnit;
        }

        public void OnGridUnitLeave()
        {
            if (GridUnit == null)
            {
                Log.Error("没有单位占据该单元格!");
                return;
            }

            GridUnit = null;
        }

        /// <summary>
        /// 是否可以经过
        /// </summary>
        /// <param name="战斗单位数据"></param>
        public bool CanAcross(BattleUnit battleUnit)
        {
            if (battleUnit == null)
            {
                return false;
            }

            if (GridType == GridType.Obstacle)
            {
                return false;
            }

            if (GridUnit != null && GridUnit.Data.CampType != battleUnit.Data.CampType)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 是否可以到达
        /// </summary>
        public bool CanArrive()
        {
            if (GridType == GridType.Obstacle || GridUnit != null)
            {
                return false;
            }

            return true;
        }
    }

    public class GridMapData : EntityData
    {
        public static Vector2Int[] s_DirArray4 = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right };
        public static Vector2Int[] s_Dir2Array4 = { Vector2Int.one, new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1) };

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
            return m_GridDataDic.ContainsKey(GridMapUtl.GridPosToIndex(gridPos));
        }

        public void SetGridData(GridData gridData)
        {
            m_GridDataDic[GridMapUtl.GridPosToIndex(gridData.GridPos)] = gridData;
        }

        public GridData GetGridData(int gridIndex)
        {
            if (m_GridDataDic.TryGetValue(gridIndex, out var gridData))
            {
                return gridData;
            }

            return null;
        }

        public GridData GetGridData(Vector2Int gridPos)
        {
            var gridIndex = GridMapUtl.GridPosToIndex(gridPos);
            if (m_GridDataDic.TryGetValue(gridIndex, out var gridData))
            {
                return gridData;
            }

            return null;
        }

        // 菱形遍历
        public List<GridData> GetRangeGridList(Vector2Int centerPos, int range)
        {
            GridData center = GetGridData(centerPos);
            List<GridData> gridList = new List<GridData>() { center };
            for (int i = 1; i <= range; ++i)
            {
                Vector2Int position = new Vector2Int(-i, 0);
                for (int k = 0; k < s_Dir2Array4.Length; ++k)
                {
                    for (int j = 0; j < i; ++j)
                    {
                        GridData gridData = GetGridData(position + center.GridPos);
                        position += s_Dir2Array4[k];
                        if (gridData != null)
                        {
                            gridList.Add(gridData);
                        }
                    }
                }
            }

            return gridList;
        }

        // 广度优先搜索
        public List<GridData> GetCanMoveGrids(BattleUnit battleUnit)
        {
            GridData start = GetGridData(battleUnit.Data.GridPos);

            Queue<GridData> open = new Queue<GridData>();
            List<GridData> close = new List<GridData>();

            open.Enqueue(start);
            for (int i = 0; i <= battleUnit.Data.MOV; ++i)
            {
                int length = open.Count;
                if (length == 0)
                {
                    break;
                }

                for (int j = 0; j < length; ++j)
                {
                    GridData gridData = open.Dequeue();
                    List<GridData> neighbors = GetNeighbors(gridData.GridPos, battleUnit, NeighborType.CanAcross);
                    foreach (var neighbor in neighbors)
                    {
                        if (!close.Contains(neighbor) && !open.Contains(neighbor))
                        {
                            open.Enqueue(neighbor);
                        }
                    }
                    close.Add(gridData);
                }
            }

            // 排除被占据的单元格
            List<GridData> canMoveList = new List<GridData>();
            foreach (var grid in close)
            {
                if (grid == start || grid.CanArrive())
                {
                    canMoveList.Add(grid);
                }
            }

            return canMoveList;
        }

        // 战斗单位可穿过的邻居
        public List<GridData> GetNeighbors(Vector2Int centerPos, BattleUnit battleUnit, NeighborType type = NeighborType.None)
        {
            GridData gridData = GetGridData(centerPos);
            List<GridData> neighbors = new List<GridData>();
            for (int i = 0; i < s_DirArray4.Length; ++i)
            {
                GridData grid = GetGridData(gridData.GridPos + s_DirArray4[i]);
                if (grid == null)
                {
                    continue;
                }

                bool flag = true;
                switch (type)
                {
                    case NeighborType.CanArrive: flag = grid.CanArrive(); break;
                    case NeighborType.CanAcross: flag = grid.CanAcross(battleUnit); break;
                }

                if (flag == false)
                {
                    continue;
                }

                neighbors.Add(grid);
            }

            return neighbors;
        }
    }
}