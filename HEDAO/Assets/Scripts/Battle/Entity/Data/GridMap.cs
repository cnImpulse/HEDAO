using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cfg;
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

    public Dictionary<int, GridData> GridDataDict;
    public Dictionary<long, GridUnit> GridUnitDict = new Dictionary<long, GridUnit>();
    
    protected override void OnInit(object data)
    {
        BattleCfg battleCfg = data as BattleCfg;
        var cfg = AssetUtl.ReadData<GridMapCfg>(AssetUtl.GetGridMapDataPath(battleCfg.MapId));
        GridDataDict = cfg.GridDataDic;

        InitPlayerBattleUnit(battleCfg, cfg);
    }

    private void InitPlayerBattleUnit(BattleCfg battleCfg, GridMapCfg cfg)
    {
        var playArea = cfg.PlayerArea.ToList();
        var roleList = GameMgr.Save.Data.TeamDict.Values.ToList();
        var gridPosList = playArea.GetRandom(roleList.Count);
        for (int i = 0; i < gridPosList.Count; ++i)
        {
            AddBattleUnit(roleList[i], gridPosList[i]);
        }

        var gridDataList = GridDataDict.Values.Where((gridData) => { return !playArea.Contains(gridData.GridPos); }).ToList().GetRandom(battleCfg.EnemyNum);
        for (int i = 0; i < gridDataList.Count; ++i)
        {
            var role = new EnemyRole();
            role.Init(battleCfg.EnemyId);
            AddBattleUnit(role, gridDataList[i].GridPos);
        }
    }

    public void AddBattleUnit(Role role, Vector2Int pos)
    {
        var gridUnit = new GridUnit();
        gridUnit.Init(role);
        gridUnit.GridPos = pos;
        GridUnitDict.Add(gridUnit.Id, gridUnit);

        var gridData = GetGridData(pos);
        gridData.OnGridUnitEnter(gridUnit);
    }

    public void RemoveGridUnit(long entityId)
    {
        GridUnitDict[entityId].GridData.OnGridUnitLeave();
        GridUnitDict.Remove(entityId);
    }

    public override int GetPrefabId()
    {
        return 10001;
    }

    public bool HasGrid(Vector2Int gridPos)
    {
        return GridDataDict.ContainsKey(GridMapUtl.GridPosToIndex(gridPos));
    }

    public void SetGrid(GridData gridData)
    {
        GridDataDict[GridMapUtl.GridPosToIndex(gridData.GridPos)] = gridData;
    }

    public GridData GetGridData(int gridIndex)
    {
        if (GridDataDict.TryGetValue(gridIndex, out var gridData))
        {
            return gridData;
        }

        return null;
    }

    public GridData GetGridData(Vector2Int gridPos)
    {
        var gridIndex = GridMapUtl.GridPosToIndex(gridPos);
        if (GridDataDict.TryGetValue(gridIndex, out var gridData))
        {
            return gridData;
        }

        return null;
    }

    public List<GridData> GetRangeGridList(Vector2Int centerPos, Cfg.Battle.GridRange gridRange, Vector2Int direction = default)
    {
        if (gridRange.Type == EGridRangeType.Default)
        {
            return GetRangeGridList(centerPos, gridRange.Distance);
        }
        else if (gridRange.Type == EGridRangeType.Cross)
        {
            return GetCrossRangeGridList(centerPos, gridRange.Distance);
        }
        else if (gridRange.Type == EGridRangeType.Square)
        {
            return GetSquareRangeGridList(centerPos, gridRange.Distance);
        }
        else if (gridRange.Type == EGridRangeType.Strip)
        {
            return GetLineRangeGridList(centerPos, gridRange.Distance, direction);
        }
    
        return null;
    }
        
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
    public List<GridData> GetCanMoveGrids(GridUnit battleUnit, int mov)
    {
        GridData start = GetGridData(battleUnit.GridPos);
    
        Queue<GridData> open = new Queue<GridData>();
        List<GridData> close = new List<GridData>();
    
        open.Enqueue(start);
        for (int i = 0; i <= mov; ++i)
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
            if (grid.CanArrive())
            {
                canMoveList.Add(grid);
            }
        }
    
        return canMoveList;
    }
    
    // 战斗单位可穿过的邻居
    public List<GridData> GetNeighbors(Vector2Int centerPos, GridUnit battleUnit, NeighborType type = NeighborType.None)
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