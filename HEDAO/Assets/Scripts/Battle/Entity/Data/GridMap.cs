using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 邻居网格类型
/// </summary>
public enum NeighborType
{
    None,
    CanAcross,
    CanArrive,
}

public class GridMap : Entity
{
    public static Vector2Int[] s_DirArray4 = { Vector2Int.down, Vector2Int.up, Vector2Int.left, Vector2Int.right };
    public static Vector2Int[] s_Dir2Array4 = { Vector2Int.one, new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1) };

    public Dictionary<int, GridData> GridDataDic;
    
    public int CfgId {get; private set;}

    public GridMap(int CfgId)
    {
        var cfg = AssetUtl.ReadData<GridMapCfg>(AssetUtl.GetGridMapDataPath(CfgId));
        GridDataDic = cfg.GridDataDic;
    }

    public bool ExitData(Vector2Int gridPos)
    {
        return GridDataDic.ContainsKey(GridMapUtl.GridPosToIndex(gridPos));
    }

    public void SetGridData(GridData gridData)
    {
        GridDataDic[GridMapUtl.GridPosToIndex(gridData.GridPos)] = gridData;
    }

    public GridData GetGridData(int gridIndex)
    {
        if (GridDataDic.TryGetValue(gridIndex, out var gridData))
        {
            return gridData;
        }

        return null;
    }

    public GridData GetGridData(Vector2Int gridPos)
    {
        var gridIndex = GridMapUtl.GridPosToIndex(gridPos);
        if (GridDataDic.TryGetValue(gridIndex, out var gridData))
        {
            return gridData;
        }

        return null;
    }

    // public List<GridData> GetRangeGridList(Vector2Int centerPos, Cfg.Battle.GridRange gridRange, Vector2Int direction = default)
    // {
    //     if (gridRange.Type == EGridRangeType.Default)
    //     {
    //         return GetRangeGridList(centerPos, gridRange.Distance);
    //     }
    //     else if (gridRange.Type == EGridRangeType.Cross)
    //     {
    //         return GetCrossRangeGridList(centerPos, gridRange.Distance);
    //     }
    //     else if (gridRange.Type == EGridRangeType.Square)
    //     {
    //         return GetSquareRangeGridList(centerPos, gridRange.Distance);
    //     }
    //     else if (gridRange.Type == EGridRangeType.Strip)
    //     {
    //         return GetLineRangeGridList(centerPos, gridRange.Distance, direction);
    //     }
    //
    //     return null;
    // }
    //     
    public List<GridData> GetSquareRangeGridList(Vector2Int centerPos, int range)
    {
        List<GridData> gridList = new List<GridData>();

        for (int x = -range; x <= range; ++x)
        {
            for (int y = -range; y <= range; ++y)
            {
                Vector2Int position = new Vector2Int(centerPos.x + x, centerPos.y + y);
                GridData gridData = GetGridData(position);
                if (gridData != null)
                {
                    gridList.Add(gridData);
                }
            }
        }

        return gridList;
    }
        
    public List<GridData> GetCrossRangeGridList(Vector2Int centerPos, int range)
    {
        GridData center = GetGridData(centerPos);
        List<GridData> gridList = new List<GridData>() { center };

        for (int i = 1; i <= range; ++i)
        {
            foreach (var dir in s_DirArray4)
            {
                Vector2Int position = centerPos + dir * i;
                GridData gridData = GetGridData(position);
                if (gridData != null)
                {
                    gridList.Add(gridData);
                }
            }
        }

        return gridList;
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

    public List<GridData> GetLineRangeGridList(Vector2Int centerPos, int range, Vector2Int direction)
    {
        List<GridData> gridList = new List<GridData>();

        for (int i = 1; i <= range; ++i)
        {
            Vector2Int position = centerPos + direction * i;
            GridData gridData = GetGridData(position);
            if (gridData != null)
            {
                gridList.Add(gridData);
            }
        }

        return gridList;
    }
        
    // 广度优先搜索
    // public List<GridData> GetCanMoveGrids(GridUnit battleUnit)
    // {
    //     GridData start = GetGridData(battleUnit.Data.GridPos);
    //
    //     Queue<GridData> open = new Queue<GridData>();
    //     List<GridData> close = new List<GridData>();
    //
    //     open.Enqueue(start);
    //     for (int i = 0; i <= battleUnit.Data.MOV; ++i)
    //     {
    //         int length = open.Count;
    //         if (length == 0)
    //         {
    //             break;
    //         }
    //
    //         for (int j = 0; j < length; ++j)
    //         {
    //             GridData gridData = open.Dequeue();
    //             List<GridData> neighbors = GetNeighbors(gridData.GridPos, battleUnit, NeighborType.CanAcross);
    //             foreach (var neighbor in neighbors)
    //             {
    //                 if (!close.Contains(neighbor) && !open.Contains(neighbor))
    //                 {
    //                     open.Enqueue(neighbor);
    //                 }
    //             }
    //             close.Add(gridData);
    //         }
    //     }
    //
    //     // 排除被占据的单元格
    //     List<GridData> canMoveList = new List<GridData>();
    //     foreach (var grid in close)
    //     {
    //         if (grid == start || grid.CanArrive())
    //         {
    //             canMoveList.Add(grid);
    //         }
    //     }
    //
    //     return canMoveList;
    // }
    //
    //     // 战斗单位可穿过的邻居
    // public List<GridData> GetNeighbors(Vector2Int centerPos, BattleUnit battleUnit, NeighborType type = NeighborType.None)
    // {
    //     GridData gridData = GetGridData(centerPos);
    //     List<GridData> neighbors = new List<GridData>();
    //     for (int i = 0; i < s_DirArray4.Length; ++i)
    //     {
    //         GridData grid = GetGridData(gridData.GridPos + s_DirArray4[i]);
    //         if (grid == null)
    //         {
    //             continue;
    //         }
    //
    //         bool flag = true;
    //         switch (type)
    //         {
    //             case NeighborType.CanArrive: flag = grid.CanArrive(); break;
    //             case NeighborType.CanAcross: flag = grid.CanAcross(battleUnit); break;
    //         }
    //
    //         if (flag == false)
    //         {
    //             continue;
    //         }
    //
    //         neighbors.Add(grid);
    //     }
    //
    //     return neighbors;
    // }
}