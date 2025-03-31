using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapCfg
{
    public Dictionary<int, GridData> GridDataDic = new Dictionary<int, GridData>();
    
    public void SetGridData(GridData gridData)
    {
        GridDataDic[GridMapUtl.GridPosToIndex(gridData.GridPos)] = gridData;
    }
}
