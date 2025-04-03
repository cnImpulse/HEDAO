using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapCfg
{
    public Dictionary<int, GridData> GridDataDic = new Dictionary<int, GridData>();
    public HashSet<Vector2Int> PlayerArea = new HashSet<Vector2Int>();

    public void SetGridData(GridData gridData)
    {
        GridDataDic[GridMapUtl.GridPosToIndex(gridData.GridPos)] = gridData;
    }
}
